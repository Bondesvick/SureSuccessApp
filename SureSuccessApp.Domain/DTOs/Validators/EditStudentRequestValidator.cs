using FluentValidation;
using SureSuccessApp.Domain.DTOs.Request;

namespace SureSuccessApp.Domain.DTOs.Validators
{
    public class EditStudentRequestValidator : AbstractValidator<EditStudentRequest>
    {
        public EditStudentRequestValidator()
        {
        }
    }
}