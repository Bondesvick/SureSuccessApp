﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SureSuccessApp.DeleteService.Filters;
using SureSuccessApp.Domain.DTOs.Request;
using SureSuccessApp.Domain.Services;

namespace SureSuccessApp.DeleteService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<DeleteController> _logger;

        public DeleteController(IStudentService studentService, ILogger<DeleteController> logger)
        {
            _studentService = studentService;
            _logger = logger;
        }

        [HttpDelete("{id:guid}")]
        [StudentExists]
        public async Task<IActionResult> Delete(Guid id)
        {
            var request = new DeleteStudentRequest { Id = id };

            await _studentService.DeleteStudentAsync(request);

            return NoContent();
        }
    }
}