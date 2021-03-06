using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using Mimirorg.TypeLibrary.Models.Application;
using TypeLibrary.Services.Contracts;

namespace TypeLibrary.Core.Controllers.V1
{
    /// <summary>
    /// TypeCm file services
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("V{version:apiVersion}/[controller]")]
    [SwaggerTag("Unit services")]
    public class LibraryUnitController : ControllerBase
    {
        private readonly ILogger<LibraryUnitController> _logger;
        private readonly IUnitService _unitService;

        public LibraryUnitController(ILogger<LibraryUnitController> logger, IUnitService unitService)
        {
            _logger = logger;
            _unitService = unitService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<UnitLibAm>), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> GetUnits()
        {
            try
            {
                var data = await _unitService.Get();
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}