﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mimirorg.Authentication.Contracts;
using Mimirorg.Authentication.Models.Application;
using Mimirorg.Authentication.Models.Attributes;
using Mimirorg.Authentication.Models.Content;
using Mimirorg.Authentication.Models.Enums;
using Mimirorg.Common.Exceptions;
using Swashbuckle.AspNetCore.Annotations;

namespace Mimirorg.Authentication.Controllers.V1
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("V{version:apiVersion}/[controller]")]
    [SwaggerTag("Mimirorg company services")]
    public class MimirorgCompanyController : ControllerBase
    {
        private readonly IMimirorgCompanyService _companyService;
        private readonly ILogger<MimirorgCompanyController> _logger;

        /// <summary>
        /// MimirorgCompanyController constructor
        /// </summary>
        /// <param name="companyService"></param>
        /// <param name="logger"></param>
        public MimirorgCompanyController(IMimirorgCompanyService companyService, ILogger<MimirorgCompanyController> logger)
        {
            _companyService = companyService;
            _logger = logger;
        }

        /// <summary>
        /// Get all registered companies
        /// </summary>
        /// <returns>ICollection&lt;MimirorgCompanyCm&gt;</returns>
        [MimirorgAuthorize(MimirorgPermission.Manage)]
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(ICollection<MimirorgCompanyCm>), 200)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Get all registered companies")]
        public async Task<IActionResult> GetCompanies()
        {
            try
            {
                var data = await _companyService.GetAllCompanies();
                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to get all companies. Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Get a specific company by id
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>MimirorgCompanyCm</returns>
        [MimirorgAuthorize(MimirorgPermission.Manage, "id")]
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(MimirorgCompanyCm), 200)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Get a specific company by id")]
        public async Task<IActionResult> GetCompany([FromRoute] int id)
        {
            try
            {
                var data = await _companyService.GetCompanyById(id);
                return Ok(data);
            }
            catch (MimirorgNotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to get company by id. Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Register a new company
        /// </summary>
        /// <param name="company">MimirorgCompanyAm</param>
        /// <returns>MimirorgCompanyCm</returns>
        [MimirorgAuthorize(MimirorgPermission.Manage)]
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(MimirorgCompanyCm), 200)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Register a new company")]
        public async Task<IActionResult> CreateCompany([FromBody] MimirorgCompanyAm company)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var data = await _companyService.CreateCompany(company);
                return Ok(data);
            }
            catch (MimirorgBadRequestException e)
            {
                foreach (var error in e.Errors().ToList())
                {
                    ModelState.Remove(error.Key);
                    ModelState.TryAddModelError(error.Key, error.Error);
                }

                return BadRequest(ModelState);
            }
            catch (MimirorgInvalidOperationException e)
            {
                _logger.LogError(e, $"An error occurred while trying to register a new company. Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to register a new company. Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Delete a registered company
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>MimirorgCompanyCm</returns>
        [MimirorgAuthorize(MimirorgPermission.Manage, "id")]
        [HttpDelete]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Delete a registered company")]
        public async Task<IActionResult> DeleteCompany([FromRoute] int id)
        {
            try
            {
                var data = await _companyService.DeleteCompany(id);
                return Ok(data);
            }
            catch (MimirorgNotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to delete tje company with id {id}. Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Update a registered company
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="company">MimirorgCompanyAm</param>
        /// <returns>MimirorgCompanyCm</returns>
        [MimirorgAuthorize(MimirorgPermission.Manage, "id")]
        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(MimirorgCompanyCm), 200)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Update a registered company")]
        public async Task<IActionResult> UpdateCompany([FromRoute] int id, [FromBody] MimirorgCompanyAm company)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var data = await _companyService.UpdateCompany(id, company);
                return Ok(data);
            }
            catch (MimirorgBadRequestException e)
            {
                foreach (var error in e.Errors().ToList())
                {
                    ModelState.Remove(error.Key);
                    ModelState.TryAddModelError(error.Key, error.Error);
                }

                return BadRequest(ModelState);
            }
            catch (MimirorgNotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"An error occurred while trying to update a company. Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
