using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SureSuccessApp.Domain.DTOs.Request;
using SureSuccessApp.Domain.DTOs.Responses;
using SureSuccessApp.Domain.Services;
using SureSuccessApp.UpdateService.Filters;
using System;
using System.Threading.Tasks;

namespace SureSuccessApp.UpdateService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UpdateController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<UpdateController> _logger;

        public UpdateController(IStudentService studentService, ILogger<UpdateController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        [ProducesResponseType(200, Type = typeof(StudentResponse))]
        [HttpPut("{id:guid}")]
        //[StudentExists]
        public async Task<IActionResult> Put(Guid id, EditStudentRequest request)
        {
            request.Id = id;
            var result = await _studentService.EditStudentAsync(request);
            return Ok(result);
        }
    }
}