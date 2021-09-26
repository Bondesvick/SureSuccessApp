using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SureSuccessApp.Domain.DTOs.Request;
using SureSuccessApp.Domain.DTOs.Responses;
using SureSuccessApp.Domain.Services;
using SureSuccessApp.ReadService.Filters;
using SureSuccessApp.ReadService.ResponseModels;

namespace SureSuccessApp.ReadService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReadController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<ReadController> _logger;

        public ReadController(IStudentService studentService, ILogger<ReadController> logger)
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

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
        {
            var result = await _studentService.GetStudentsAsync();

            var totalItems = result.Count();

            var itemsOnPage = result
                .OrderBy(c => c.FirstName)
                .Skip(pageSize * pageIndex)
                .Take(pageSize);

            var model = new PaginatedStudentResponseModel<StudentResponse>(
                pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }
    }
}