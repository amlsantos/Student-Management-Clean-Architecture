﻿namespace Application.Interfaces;

public interface IUnitOfWork
{
    public IStudentRepository Students { get; }
    public IEnrollmentRepository Enrollments { get; }
    public ICourseRepository Courses { get; }
    
    public Task CommitAsync();
}