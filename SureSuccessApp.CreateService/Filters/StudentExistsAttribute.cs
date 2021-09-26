using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SureSuccessApp.Domain.DTOs.Request;
using SureSuccessApp.Domain.Services;
using System;
using System.Threading.Tasks;

namespace SureSuccessApp.CreateService.Filters
{
    public class StudentExistsAttribute : TypeFilterAttribute
    {
        public StudentExistsAttribute() : base(typeof
            (StudentExistsFilterImpl))
        {
        }

        public class StudentExistsFilterImpl : IAsyncActionFilter
        {
            private readonly StudentService _studentService;

            public StudentExistsFilterImpl(StudentService studentService)
            {
                _studentService = studentService;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context,
                ActionExecutionDelegate next)
            {
                if (!(context.ActionArguments["id"] is Guid id))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                var result = await _studentService.GetStudentAsync(new GetStudentRequest { Id = id });

                if (result == null)
                {
                    context.Result = new NotFoundObjectResult(new JsonErrorPayload
                    { DetailedMessage = $"Student with id {id} not exist." });
                    return;
                }

                await next();
            }
        }
    }
}