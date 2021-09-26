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