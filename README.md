#

## Introduction
This is a sample Rest API, using **Clean Architecture**, **CQRS** and **Microsoft .NET 7**. 

We are also using some functional programing concepts such as: 
- ``Maybe<T>`` - to avoid Nulls with the Maybe Type
- ``Result`` - to handle failures and Input Errors in a Functional Way


### Context
> 


### Persistence layer
We have 3 repositories, and we are using the **unit of work** pattern:

- `StudentRepository`
- `CourseRepository`
- `EnrollmenttRepository`

### Api layer

**Courses endpoints**

- GET `/Courses` - returns all courses
- POST `/Courses` - creates a new course
- GET `/Courses/{id}` - returns a course by id
- GET `/Courses/GetByName/{name}` - returns a course by name
- DELETE `/Courses/{id}` - deletes a course by id

**Enrollments endpoints**

- GET `/Enrollments` - returns all enrollments

**Students endpoints**

- GET `/students` - returns all students
- POST `/students` - creates a new student
- DELETE `/students/{id}` - deletes a student by id
- PUT `/students/{id}` - updates a student by id
- POST `/students/{id}/enrollments` - adds a student to a course
- PUT `/students/{id}/enrollments/{enrollmentNumber}` - updates a student with a course
- DELETE `/posts/{id}` - deletes a post by id
- POST `/students/{id}/enrollments/{enrollmentNumber}/deletion` - deletes a student from a course

#### Request validations (using Fluent Validation)
**Student**

- `Id` should not be null
- `Name` should not be empty
- `Email` should not be empty

**Enrollment**

- `Id` should not be null
- `Student` should not be empty
- `Course` should not be empty
- `Grade` should not be empty

**Course**

- `Id` should not be null
- `Name` should not be empty
- `Credits` should not be null

## Technologies
This demo application uses the following technologies:
 - .NET 7
 - C# 11
 - ASP.NET Core MVC 7.0
 - EF Core 7.0
 - Rider 2022
 - SQL Server 2022
 - MediatR 11.1
 - Fluent Validation 11.2
