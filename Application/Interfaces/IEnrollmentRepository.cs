﻿using StudentManagementSystem.Entities;

namespace Application.Interfaces;

public interface IEnrollmentRepository
{
    public Task<IEnumerable<Enrollment>> GetAll();
    public Task Save(Enrollment enrollment);
    public Task Delete(Enrollment enrollment);
}