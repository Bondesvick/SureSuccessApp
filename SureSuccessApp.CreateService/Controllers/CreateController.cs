using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SureSuccessApp.CreateService.Filters;
using SureSuccessApp.Domain.DTOs.Request;
using SureSuccessApp.Domain.DTOs.Responses;
using SureSuccessApp.Domain.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SureSuccessApp.CreateService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<CreateController> _logger;

        public CreateController(IStudentService studentService, ILogger<CreateController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(StudentResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(200, Type = typeof(StudentResponse))]
        [HttpGet("{id:guid}")]
        //[StudentExists]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _studentService.GetStudentAsync(new GetStudentRequest { Id = id });
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError("An error occurred -> " + e.Message, e);
                Console.WriteLine(e);
                throw;
            }
        }

        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(StudentResponse), (int)HttpStatusCode.Created)]
        [HttpPost]
        public async Task<IActionResult> Post(AddStudentRequest request)
        {
            try
            {
                var result = await _studentService.AddStudentAsync(request);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (Exception e)
            {
                _logger.LogError("An error occurred -> " + e.Message, e);
                Console.WriteLine(e);
                throw;
            }
        }
    }
}