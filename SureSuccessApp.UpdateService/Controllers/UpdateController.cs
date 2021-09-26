using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SureSuccessApp.Domain.DTOs.Request;
using SureSuccessApp.Domain.Services;
using SureSuccessApp.UpdateService.Filters;

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

        [HttpPut("{id:guid}")]
        [StudentExists]
        public async Task<IActionResult> Put(Guid id, EditStudentRequest request)
        {
            request.Id = id;
            var result = await _studentService.EditStudentAsync(request);
            return Ok(result);
        }
    }
}