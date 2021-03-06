using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mimirorg.Authentication.Contracts;
using Mimirorg.Authentication.Models.Attributes;
using Mimirorg.Common.Exceptions;
using Mimirorg.TypeLibrary.Enums;
using Mimirorg.TypeLibrary.Models.Application;
using Mimirorg.TypeLibrary.Models.Client;
using Swashbuckle.AspNetCore.Annotations;
using TypeLibrary.Services.Contracts;

namespace TypeLibrary.Core.Controllers.V1
{
    /// <summary>
    /// Library services
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("V{version:apiVersion}/[controller]")]
    [SwaggerTag("Library Node Services")]
    public class LibraryNodeController : ControllerBase
    {
        private readonly ILogger<LibraryNodeController> _logger;
        private readonly INodeService _nodeService;
        private readonly IMimirorgUserService _userService;

        public LibraryNodeController(ILogger<LibraryNodeController> logger, INodeService nodeService, IMimirorgUserService userService)
        {
            _logger = logger;
            _nodeService = nodeService;
            _userService = userService;
        }

        /// <summary>
        /// Get node by id
        /// </summary>
        /// <param name="id">node id</param>
        /// <returns>The content if exist or </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(NodeLibCm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var cm = await _nodeService.Get(id);
                return Ok(cm);
            }
            catch (MimirorgBadRequestException e)
            {
                _logger.LogWarning(e, $"Warning error: {e.Message}");

                foreach (var error in e.Errors().ToList())
                {
                    ModelState.Remove(error.Key);
                    ModelState.TryAddModelError(error.Key, error.Error);
                }

                return BadRequest(ModelState);
            }
            catch (MimirorgNotFoundException)
            {
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Get all nodes
        /// </summary>
        /// <returns>A collection of nodes</returns>
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<NodeLibCm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetLatestVersions()
        {
            try
            {
                var cm = await _nodeService.GetLatestVersions();
                return Ok(cm);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Create a node
        /// </summary>
        /// <param name="node">The node that should be created</param>
        /// <returns>The created node</returns>
        [HttpPost]
        [ProducesResponseType(typeof(NodeLibCm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [MimirorgAuthorize(MimirorgPermission.Write, "node", "CompanyId")]
        public async Task<IActionResult> Create([FromBody] NodeLibAm node)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var cm = await _nodeService.Create(node);
                return Ok(cm);
            }
            catch (MimirorgBadRequestException e)
            {
                _logger.LogWarning(e, $"Warning error: {e.Message}");

                foreach (var error in e.Errors().ToList())
                {
                    ModelState.Remove(error.Key);
                    ModelState.TryAddModelError(error.Key, error.Error);
                }

                return BadRequest(ModelState);
            }
            catch (MimirorgDuplicateException e)
            {
                ModelState.Remove("Id");
                ModelState.TryAddModelError("Id", e.Message);
                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Update node
        /// </summary>
        /// <param name="dataAm"></param>
        /// <param name="id"></param>
        /// <returns>NodeLibCm</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(NodeLibCm), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [MimirorgAuthorize(MimirorgPermission.Write, "dataAm", "CompanyId")]
        public async Task<IActionResult> Update([FromBody] NodeLibAm dataAm, [FromRoute] string id)
        {
            try
            {
                var companyIsChanged = await _nodeService.CompanyIsChanged(id, dataAm.CompanyId);
                if (companyIsChanged)
                    return StatusCode(StatusCodes.Status403Forbidden);

                var data = await _nodeService.Update(dataAm, id);
                return Ok(data);
            }
            catch (MimirorgBadRequestException e)
            {
                _logger.LogWarning(e, $"Warning error: {e.Message}");

                foreach (var error in e.Errors().ToList())
                {
                    ModelState.Remove(error.Key);
                    ModelState.TryAddModelError(error.Key, error.Error);
                }

                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Delete a node
        /// </summary>
        /// <param name="id"></param>
        /// <returns>200</returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation("Delete a node")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            try
            {
                var node = await _nodeService.Get(id);

                if (node == null)
                    return NotFound($"Can't find node with id: {id}");

                var currentUser = await _userService.GetUser(HttpContext.User);
                if (!currentUser.Permissions.TryGetValue(node.CompanyId, out var permission))
                    return StatusCode(StatusCodes.Status403Forbidden);

                if (!permission.HasFlag(MimirorgPermission.Delete))
                    return StatusCode(StatusCodes.Status403Forbidden);

                var data = await _nodeService.Delete(id);
                return Ok(data);
            }
            catch (MimirorgBadRequestException e)
            {
                _logger.LogWarning(e, $"Warning error: {e.Message}");

                foreach (var error in e.Errors().ToList())
                {
                    ModelState.Remove(error.Key);
                    ModelState.TryAddModelError(error.Key, error.Error);
                }

                return BadRequest(ModelState);
            }
            catch (MimirorgNotFoundException)
            {
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Internal Server Error: Error: {e.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}