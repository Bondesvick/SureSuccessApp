using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SureSuccessApp.CreateService.Filters;
using SureSuccessApp.Domain.DTOs.Request;
using SureSuccessApp.Domain.Services;

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

        [HttpGet("{id:guid}")]
        [StudentExists]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _studentService.GetStudentAsync(new GetStudentRequest { Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddStudentRequest request)
        {
            var result = await _studentService.AddStudentAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, null);
        }
    }
}