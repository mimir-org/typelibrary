﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TypeLibrary.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mimirorg.Common.Exceptions;
using Swashbuckle.AspNetCore.Annotations;
using TypeLibrary.Models.Models.Application;
using TypeLibrary.Models.Models.Client;
using TypeLibrary.Models.Models.Data;
using TypeLibrary.Services.Contracts;

namespace TypeLibrary.Core.Controllers.V1
{
    /// <summary>
    /// TypeDm services
    /// </summary>
    [Produces("application/json")]
    //[Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("V{version:apiVersion}/[controller]")]
    [SwaggerTag("TypeDm")]
    public class TypeController : ControllerBase
    {
        private readonly ILogger<TypeController> _logger;
        private readonly ITypeService _typeService;

        public TypeController(ILogger<TypeController> logger, ITypeService typeService)
        {
            _logger = logger;
            _typeService = typeService;
        }

        #region Types

        /// <summary>
        /// Get all types by search
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(TypeCm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Authorize(Policy = "Read")]
        public async Task<IActionResult> GetType(string name)
        {
            try
            {
                var typeCm = await _typeService.GetType(name);
                return Ok(typeCm);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        

        /// <summary>
        /// Get a typeDm
        /// </summary>
        /// <param name="id"></param>
        /// <param name="libraryFilter"></param>
        /// <returns></returns>
        [HttpGet("{id}/{libraryFilter}")]
        [ProducesResponseType(typeof(TypeAm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Authorize(Policy = "Read")]
        public async Task<IActionResult> GetType([Required] string id, [Required] LibraryFilter libraryFilter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var data = await _typeService.ConvertToCreateType(id, libraryFilter);
                return Ok(data);
            }
            catch (MimirorgNotFoundException e)
            {
                ModelState.AddModelError("Not found", e.Message);
                return BadRequest(ModelState);
            }
            catch (MimirorgInvalidOperationException e)
            {
                ModelState.AddModelError("Invalid value", e.Message);
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Create a typeDm
        /// </summary>
        /// <param name="typeAm"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(TypeDm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Authorize(Policy = "Edit")]
        public async Task<IActionResult> CreateType([FromBody] TypeAm typeAm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (typeAm.Aspect == Aspect.Location)
                    typeAm.ObjectType = ObjectType.ObjectBlock;
                

                switch (typeAm.ObjectType)
                {
                    case ObjectType.ObjectBlock:
                        var ob = await _typeService.CreateType<NodeCm>(typeAm);
                        return Ok(ob);

                    case ObjectType.Transport:
                        var ln = await _typeService.CreateType<TransportCm>(typeAm);
                        return Ok(ln);

                    case ObjectType.Interface:
                        var libraryInterfaceItem = await _typeService.CreateType<InterfaceCm>(typeAm);
                        return Ok(libraryInterfaceItem);

                    default:
                        throw new MimirorgInvalidOperationException($"Can't create typeAm of: {typeAm.ObjectType}");
                }
            }
            catch (MimirorgDuplicateException e)
            {
                ModelState.AddModelError("Duplicate", e.Message);
                return BadRequest(ModelState);
            }
            catch (MimirorgNullReferenceException e)
            {
                ModelState.AddModelError("Duplicate", e.Message);
                return BadRequest(ModelState);
            }
            catch (MimirorgInvalidOperationException e)
            {
                ModelState.AddModelError("Duplicate", e.Message);
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Update a typeDm
        /// </summary>
        /// <param name="id"></param>
        /// <param name="typeAm"></param>
        /// <param name="updateMajorVersion"></param>
        /// <param name="updateMinorVersion"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        [ProducesResponseType(typeof(TypeDm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Authorize(Policy = "Edit")]
        public async Task<IActionResult> UpdateType(string id, [FromBody] TypeAm typeAm,
            bool updateMajorVersion = false, bool updateMinorVersion = false)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                switch (typeAm.ObjectType)
                {
                    case ObjectType.ObjectBlock:
                        var ob = await _typeService.UpdateType<NodeCm>(id, typeAm, updateMajorVersion, updateMinorVersion);
                        return Ok(ob);

                    case ObjectType.Transport:
                        var ln = await _typeService.UpdateType<TransportCm>(id, typeAm, updateMajorVersion, updateMinorVersion);
                        return Ok(ln);

                    case ObjectType.Interface:
                        var interfaceCm = await _typeService.UpdateType<InterfaceCm>(id, typeAm, updateMajorVersion, updateMinorVersion);
                        return Ok(interfaceCm);

                    default:
                        throw new MimirorgInvalidOperationException($"Can't create typeAm of: {typeAm.ObjectType}");
                }
            }
            catch (MimirorgNullReferenceException e)
            {
                ModelState.AddModelError("Bad request", e.Message);
                return BadRequest(ModelState);
            }
            catch (MimirorgNotFoundException e)
            {
                ModelState.AddModelError("Bad request", e.Message);
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Delete a typeDm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteType(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("The id could not be null or empty");

            try
            {
                await _typeService.DeleteType(id);
                return Ok(true);
            }
            catch (MimirorgNotFoundException e)
            {
                return NotFound(e);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        #endregion Types


        #region SubProject

        /// <summary>
        /// Get subProjects
        /// </summary>
        /// <returns></returns>
        [HttpGet("subProject")]
        [ProducesResponseType(typeof(ICollection<SubProjectCm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Policy = "Read")]
        public async Task<IActionResult> GetSubProjects()
        {
            try
            {
                var subProjectCmList = await _typeService.GetSubProjects();
                return Ok(subProjectCmList.ToList());
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        #endregion SubProject


        #region NodeDm

        /// <summary>
        /// Get all nodes
        /// </summary>
        /// <returns></returns>
        [HttpGet("node")]
        [ProducesResponseType(typeof(ICollection<NodeCm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Authorize(Policy = "Read")]
        public async Task<IActionResult> GetNodes()
        {
            try
            {
                var data = await _typeService.GetNodes();
                return Ok(data.ToList());
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        #endregion NodeDm


        #region Transport

        /// <summary>
        /// Get transport types
        /// </summary>
        /// <returns></returns>
        [HttpGet("transport")]
        [ProducesResponseType(typeof(ICollection<TransportCm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Policy = "Read")]
        public async Task<IActionResult> GetTransports()
        {
            try
            {
                var data = await _typeService.GetTransports();
                return Ok(data.ToList());
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        #endregion Transport


        #region Interface

        /// <summary>
        /// Get interface types
        /// </summary>
        /// <returns></returns>
        [HttpGet("interface")]
        [ProducesResponseType(typeof(ICollection<InterfaceCm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Policy = "Read")]
        public async Task<IActionResult> GetInterfaces()
        {
            try
            {
                var data = await _typeService.GetInterfaces();
                return Ok(data.ToList());
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        #endregion Interface


        #region SimpleDm

        /// <summary>
        /// Get all simple types
        /// </summary>
        /// <returns></returns>
        [HttpGet("simple")]
        [ProducesResponseType(typeof(IEnumerable<SimpleDm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Policy = "Read")]
        public IActionResult GetSimpleTypes()
        {
            try
            {
                var types = _typeService.GetSimpleTypes().ToList();
                return Ok(types);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Create a simple typeAm
        /// </summary>
        /// <returns></returns>
        [HttpPost("simple")]
        [ProducesResponseType(typeof(IEnumerable<TypeDm>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[Authorize(Policy = "Edit")]
        public async Task<IActionResult> CreateSimple(SimpleAm simpleAm)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var simple = await _typeService.CreateSimpleType(simpleAm);
                return StatusCode(201, simple);
            }
            catch (MimirorgDuplicateException e)
            {
                ModelState.AddModelError("Duplicate", e.Message);
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        #endregion SimpleDm
    }
}