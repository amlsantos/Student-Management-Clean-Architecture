using Api.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Entities;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;

    public StudentsController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    [HttpGet]
    public async Task<IActionResult> GetList(string enrolled, int? number)
    {
        var students = await _unitOfWork.Students.GetList(enrolled, number);
        var dtos = students.Select(x => ConvertToDto(x)).ToList();

        return Ok(dtos);
    }

    private StudentDto ConvertToDto(Student student)
    {
        return new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email,
            Course1 = student.FirstEnrollment?.Course?.Name,
            Course1Grade = student.FirstEnrollment?.Grade.ToString(),
            Course1Credits = student.FirstEnrollment?.Course?.Credits,
            Course2 = student.SecondEnrollment?.Course?.Name,
            Course2Grade = student.SecondEnrollment?.Grade.ToString(),
            Course2Credits = student.SecondEnrollment?.Course?.Credits,
        };
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] StudentDto dto)
    {
        var student = new Student(dto.Name, dto.Email);

        if (dto.Course1 != null && dto.Course1Grade != null)
        {
            var course = await _unitOfWork.Courses.GetByName(dto.Course1);
            student.Enroll(course, Enum.Parse<Grade>(dto.Course1Grade));
        }

        if (dto.Course2 != null && dto.Course2Grade != null)
        {
            var course = await _unitOfWork.Courses.GetByName(dto.Course2);
            student.Enroll(course, Enum.Parse<Grade>(dto.Course2Grade));
        }

        await _unitOfWork.Students.SaveAsync(student);
        await _unitOfWork.CommitAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var student = await _unitOfWork.Students.GetById(id);
        if (student == null)
            return Error($"No student found for Id {id}");

        await _unitOfWork.Students.Delete(student);
        await _unitOfWork.CommitAsync();

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] StudentDto dto)
    {
        var student = await _unitOfWork.Students.GetById(id);
        if (student == null)
            return Error($"No student found for Id {id}");

        student.Name = dto.Name;
        student.Email = dto.Email;

        var firstEnrollment = student.FirstEnrollment;
        var secondEnrollment = student.SecondEnrollment;

        if (HasEnrollmentChanged(dto.Course1, dto.Course1Grade, firstEnrollment))
        {
            if (string.IsNullOrWhiteSpace(dto.Course1)) // Student disenrolls
            {
                if (string.IsNullOrWhiteSpace(dto.Course1DisenrollmentComment))
                    return Error("Disenrollment comment is required");

                var enrollment = firstEnrollment;
                student.RemoveEnrollment(enrollment);
                student.AddDisenrollmentComment(enrollment, dto.Course1DisenrollmentComment);
            }

            if (string.IsNullOrWhiteSpace(dto.Course1Grade))
                return Error("Grade is required");

            var course = await _unitOfWork.Courses.GetByName(dto.Course1);

            if (firstEnrollment == null)
            {
                // Student enrolls
                student.Enroll(course, Enum.Parse<Grade>(dto.Course1Grade));
            }
            else
            {
                // Student transfers
                firstEnrollment.Update(course, Enum.Parse<Grade>(dto.Course1Grade));
            }
        }

        if (HasEnrollmentChanged(dto.Course2, dto.Course2Grade, secondEnrollment))
        {
            if (string.IsNullOrWhiteSpace(dto.Course2)) // Student disenrolls
            {
                if (string.IsNullOrWhiteSpace(dto.Course2DisenrollmentComment))
                    return Error("Disenrollment comment is required");

                var enrollment = secondEnrollment;
                student.RemoveEnrollment(enrollment);
                student.AddDisenrollmentComment(enrollment, dto.Course2DisenrollmentComment);
            }

            if (string.IsNullOrWhiteSpace(dto.Course2Grade))
                return Error("Grade is required");

            var course = await _unitOfWork.Courses.GetByName(dto.Course2);
            if (secondEnrollment == null)
            {
                // Student enrolls
                student.Enroll(course, Enum.Parse<Grade>(dto.Course2Grade));
            }
            else
            {
                // Student transfers
                secondEnrollment.Update(course, Enum.Parse<Grade>(dto.Course2Grade));
            }
        }

        await _unitOfWork.CommitAsync();

        return Ok();
    }

    private bool HasEnrollmentChanged(string newCourseName, string newGrade, Enrollment enrollment)
    {
        if (string.IsNullOrWhiteSpace(newCourseName) && enrollment == null)
            return false;

        if (string.IsNullOrWhiteSpace(newCourseName) || enrollment == null)
            return true;

        return newCourseName != enrollment.Course.Name || newGrade != enrollment.Grade.ToString();
    }
}