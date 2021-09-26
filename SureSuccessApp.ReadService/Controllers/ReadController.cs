using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SureSuccessApp.Domain.DTOs.Request;
using SureSuccessApp.Domain.DTOs.Responses;
using SureSuccessApp.Domain.Services;
using SureSuccessApp.ReadService.Filters;
using SureSuccessApp.ReadService.ResponseModels;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        [ProducesResponseType(200, Type = typeof(StudentResponse))]
        [HttpGet("{id:guid}")]
        [StudentExists]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _studentService.GetStudentAsync(new GetStudentRequest { Id = id });
            return Ok(result);
        }

        [ProducesResponseType(200, Type = typeof(PaginatedStudentResponseModel<StudentResponse>))]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 1)
        {
            var result = await _studentService.GetStudentsAsync();

            var studentResponses = result as StudentResponse[] ?? result.ToArray();
            var totalItems = studentResponses.Count();

            var itemsOnPage = studentResponses
                .OrderBy(c => c.FirstName)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize);

            var model = new PaginatedStudentResponseModel<StudentResponse>(
                pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }
    }
}