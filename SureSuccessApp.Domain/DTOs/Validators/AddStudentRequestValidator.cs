using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SureSuccessApp.Domain.DTOs.Request;

namespace SureSuccessApp.Domain.DTOs.Validators
{
    public class AddStudentRequestValidator : AbstractValidator<AddStudentRequest>
    {
        public AddStudentRequestValidator()
        {
        }
    }
}