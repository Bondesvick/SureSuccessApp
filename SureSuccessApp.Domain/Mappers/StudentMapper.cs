using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SureSuccessApp.Domain.DTOs.Request;
using SureSuccessApp.Domain.DTOs.Responses;
using SureSuccessApp.Domain.Entities;

namespace SureSuccessApp.Domain.Mappers
{
    public class StudentMapper : IStudentMapper
    {
        public StudentMapper()
        {
        }

        public Student Map(AddStudentRequest request)
        {
            if (request == null) return null;

            var student = new Student()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Email = request.Email,
                State = request.State,
                Country = request.Country
            };

            return student;
        }

        public Student Map(EditStudentRequest request)
        {
            if (request == null) return null;

            var student = new Student()
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Email = request.Email,
                State = request.State,
                Country = request.Country
            };

            return student;
        }

        public StudentResponse Map(Student request)
        {
            if (request == null) return null;

            var student = new StudentResponse()
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Email = request.Email,
                State = request.State,
                Country = request.Country
            };

            return student;
        }
    }
}