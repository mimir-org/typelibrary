﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mimirorg.Authentication.Contracts;
using Mimirorg.Common.Enums;
using Swashbuckle.AspNetCore.Annotations;
using Mimirorg.TypeLibrary.Models.Application;
using TypeLibrary.Services.Contracts;

namespace TypeLibrary.Core.Controllers.V1
{
    /// <summary>
    /// TypeCm file services
    /// </summary>
    [Produces("application/json")]
    //[Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("V{version:apiVersion}/[controller]")]
    [SwaggerTag("Qualifier services")]
    public class LibraryAttributeQualifierController : ControllerBase
    {
        private readonly ILogger<LibraryAttributeQualifierController> _logger;
        private readonly IAttributeQualifierService _attributeQualifierService;
        private readonly ITimedHookService _hookService;

        public LibraryAttributeQualifierController(ILogger<LibraryAttributeQualifierController> logger, IAttributeQualifierService attributeQualifierService, ITimedHookService hookService)
        {
            _logger = logger;
            _attributeQualifierService = attributeQualifierService;
            _hookService = hookService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<AttributeQualifierLibAm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Read")]
        public async Task<IActionResult> GetQualifiers()
        {
            try
            {
                var data = await _attributeQualifierService.GetAttributeQualifiers();
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AttributeQualifierLibAm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Edit")]
        public async Task<IActionResult> UpdateQualifier([FromBody] AttributeQualifierLibAm dataAm, [FromRoute] int id)
        {
            try
            {
                _hookService.HookQueue.Enqueue(CacheKey.AttributeQualifier);
                var data = await _attributeQualifierService.UpdateAttributeQualifier(dataAm, id);
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(AttributeQualifierLibAm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateQualifier([FromBody] AttributeQualifierLibAm dataAm)
        {
            try
            {
                var data = await _attributeQualifierService.CreateAttributeQualifier(dataAm);
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