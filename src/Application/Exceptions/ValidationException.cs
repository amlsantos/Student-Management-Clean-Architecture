﻿using ApplicationException = StudentManagementSystem.Exceptions.ApplicationException;

namespace Application.Exceptions;

public class ValidationException : ApplicationException
{
    public ValidationException(IReadOnlyDictionary<string, string[]> errorsDictionary) : base("Validation Failure", "One or more validation errors occurred") 
        => ErrorsDictionary = errorsDictionary;

    public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }
}