﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using TypeLibrary.Models.Application;
using TypeLibrary.Services.Contracts;

namespace TypeLibrary.Core.Controllers.V1
{
    /// <summary>
    /// Library file services
    /// </summary>
    [Produces("application/json")]
    //[Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("V{version:apiVersion}/[controller]")]
    [SwaggerTag("EnumController")]
    public class EnumController : ControllerBase
    {
        private readonly ILogger<AttributeTypeController> _logger;
        private readonly IEnumService _enumService;

        public EnumController(ILogger<AttributeTypeController> logger, IEnumService enumService)
        {
            _logger = logger;
            _enumService = enumService;
        }

        #region Condition

        [HttpGet("condition")]
        [ProducesResponseType(typeof(ICollection<ConditionAm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Read")]
        public async Task<IActionResult> GetConditions()
        {
            try
            {
                var data = await _enumService.GetConditions();
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("condition")]
        [ProducesResponseType(typeof(ConditionAm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Edit")]
        public async Task<IActionResult> UpdateCondition([FromBody] ConditionAm dataAm)
        {
            try
            {
                var data = await _enumService.UpdateCondition(dataAm);
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("condition")]
        [ProducesResponseType(typeof(ConditionAm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateCondition([FromBody] ConditionAm dataAm)
        {
            try
            {
                var data = await _enumService.CreateCondition(dataAm);
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        #endregion Condition


        #region Format

        [HttpGet("format")]
        [ProducesResponseType(typeof(ICollection<FormatAm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Read")]
        public async Task<IActionResult> GetFormats()
        {
            try
            {
                var data = await _enumService.GetFormats();
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("format")]
        [ProducesResponseType(typeof(FormatAm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Edit")]
        public async Task<IActionResult> UpdateFormat([FromBody] FormatAm dataAm)
        {
            try
            {
                var data = await _enumService.UpdateFormat(dataAm);
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("format")]
        [ProducesResponseType(typeof(FormatAm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateFormat([FromBody] FormatAm dataAm)
        {
            try
            {
                var data = await _enumService.CreateFormat(dataAm);
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        #endregion Format


        #region Qualifier

        [HttpGet("qualifier")]
        [ProducesResponseType(typeof(ICollection<QualifierAm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Read")]
        public async Task<IActionResult> GetQualifiers()
        {
            try
            {
                var data = await _enumService.GetQualifiers();
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("qualifier")]
        [ProducesResponseType(typeof(QualifierAm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Edit")]
        public async Task<IActionResult> UpdateQualifier([FromBody] QualifierAm dataAm)
        {
            try
            {
                var data = await _enumService.UpdateQualifier(dataAm);
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("qualifier")]
        [ProducesResponseType(typeof(QualifierAm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateQualifier([FromBody] QualifierAm dataAm)
        {
            try
            {
                var data = await _enumService.CreateQualifier(dataAm);
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        #endregion Qualifier


        #region Source

        [HttpGet("Source")]
        [ProducesResponseType(typeof(ICollection<SourceAm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Read")]
        public async Task<IActionResult> GetSources()
        {
            try
            {
                var data = await _enumService.GetSources();
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("source")]
        [ProducesResponseType(typeof(SourceAm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Edit")]
        public async Task<IActionResult> UpdateSource([FromBody] SourceAm dataAm)
        {
            try
            {
                var data = await _enumService.UpdateSource(dataAm);
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("source")]
        [ProducesResponseType(typeof(SourceAm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateSource([FromBody] SourceAm dataAm)
        {
            try
            {
                var data = await _enumService.CreateSource(dataAm);
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        #endregion Source


        #region Location

        [HttpGet("location")]
        [ProducesResponseType(typeof(ICollection<LocationAm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Read")]
        public async Task<IActionResult> GetLocations()
        {
            try
            {
                var data = await _enumService.GetLocations();
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("location")]
        [ProducesResponseType(typeof(LocationAm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Edit")]
        public async Task<IActionResult> UpdateLocation([FromBody] LocationAm dataAm)
        {
            try
            {
                var data = await _enumService.UpdateLocation(dataAm);
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("location")]
        [ProducesResponseType(typeof(LocationAm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateLocation([FromBody] LocationAm dataAm)
        {
            try
            {
                var data = await _enumService.CreateLocation(dataAm);
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        #endregion Location


        #region Purpose

        [HttpGet("purpose")]
        [ProducesResponseType(typeof(ICollection<PurposeAm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Read")]
        public async Task<IActionResult> GetPurposes()
        {
            try
            {
                var data = await _enumService.GetPurposes();
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("purpose")]
        [ProducesResponseType(typeof(PurposeAm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Edit")]
        public async Task<IActionResult> UpdatePurpose([FromBody] PurposeAm dataAm)
        {
            try
            {
                var data = await _enumService.UpdatePurpose(dataAm);
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("purpose")]
        [ProducesResponseType(typeof(PurposeAm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreatePurpose([FromBody] PurposeAm dataAm)
        {
            try
            {
                var data = await _enumService.CreatePurpose(dataAm);
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        #endregion Purpose


        #region RdsCategory

        [HttpGet("rdsCategory")]
        [ProducesResponseType(typeof(ICollection<RdsCategoryAm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Read")]
        public async Task<IActionResult> GetRdsCategories()
        {
            try
            {
                var data = await _enumService.GetRdsCategories();
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("rdsCategory")]
        [ProducesResponseType(typeof(RdsCategoryAm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Edit")]
        public async Task<IActionResult> UpdateRdsCategory([FromBody] RdsCategoryAm dataAm)
        {
            try
            {
                var data = await _enumService.UpdateRdsCategory(dataAm);
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("rdsCategory")]
        [ProducesResponseType(typeof(RdsCategoryAm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateRdsCategory([FromBody] RdsCategoryAm dataAm)
        {
            try
            {
                var data = await _enumService.CreateRdsCategory(dataAm);
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        #endregion RdsCategory


        #region Unit

        [HttpGet("unit")]
        [ProducesResponseType(typeof(ICollection<UnitAm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Read")]
        public async Task<IActionResult> GetUnits()
        {
            try
            {
                var data = await _enumService.GetUnits();
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("unit")]
        [ProducesResponseType(typeof(UnitAm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Edit")]
        public async Task<IActionResult> UpdateUnit([FromBody] UnitAm dataAm)
        {
            try
            {
                var data = await _enumService.UpdateUnit(dataAm);
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost("unit")]
        [ProducesResponseType(typeof(UnitAm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateUnit([FromBody] UnitAm dataAm)
        {
            try
            {
                var data = await _enumService.CreateUnit(dataAm);
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        #endregion Unit
    }
}