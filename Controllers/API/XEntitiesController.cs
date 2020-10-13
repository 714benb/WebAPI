using Microsoft.AspNetCore.Mvc;
using WebAPI.API.Domain.Services;
using WebAPI.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using WebAPI.API.Resources;
using WebAPI.API.Extensions;
using WebAPI.Resources;

namespace WebAPI.API.Controllers
{
    [Route("/api/[controller]")]
    public class XEntitiesController: ControllerBase
    {
        
        private readonly IXEntityService _xEntityService;
        private readonly IMapper _mapper;

        public XEntitiesController(IXEntityService xEntityService, IMapper mapper)
        {
            _xEntityService = xEntityService;
            _mapper = mapper;
        }
        /// <summary>
        /// List all the xEntities;
        /// </summary>
        /// <returns>
        /// an enumerable list of xEntities;
        /// </returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<XEntityResource>), 200)]
        public async Task<IEnumerable<XEntityResource>> GetAllAsync()
        {
            var XEntities = await _xEntityService.ListAsync();
            var resources = _mapper.Map<IEnumerable<XEntity>,IEnumerable<XEntityResource>>(XEntities);
            return resources;
        }

        /// <summary>
        /// Saves/Creates a new xEntity.
        /// </summary>
        /// <param name="resource">The xEntity data</param>
        /// <returns>
        /// A response that indicates failure (400) or success (201) and the xEntity data
        /// </returns>
        [HttpPost]
        [ProducesResponseType(typeof(XEntityResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveXEntityResource resource)
        {
            var xEntity = _mapper.Map<SaveXEntityResource, XEntity>(resource);
            var result = await _xEntityService.SaveAsync(xEntity);
            if (false == result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var xEntityResource = _mapper.Map<XEntity, XEntityResource>(result.Resource);
            return Ok(xEntityResource);
        }

        /// <summary>
        /// Updates and existing xEntity if one exist for the given identifier
        /// </summary>
        /// <param name="id">The xEntity identifier</param>
        /// <param name="resource">The data to be used for the update.</param>
        /// <returns>
        /// A response that indicates failure (400) or success (200) and the xEntity data
        /// </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(XEntityResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveXEntityResource resource)
        {
            var xEntity = _mapper.Map<SaveXEntityResource, XEntity>(resource);
            var result = await _xEntityService.UpdateAsync(id, xEntity);

            if (false == result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var xEntityResource = _mapper.Map<XEntity, XEntityResource>(result.Resource);

            return Ok(xEntityResource);
        }

        /// <summary>
        /// Delete the xEntity if found by the given identifier
        /// </summary>
        /// <param name="id">The xEntity identifier</param>
        /// <returns>
        /// A response that indicates failure (400) or success (200) and the xEntity data
        /// </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(XEntityResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _xEntityService.DeleteAsync(id);

            if (false == result.Success)
            {
                return BadRequest(result.Message);
            }

            var xEntityResource = _mapper.Map<XEntity, XEntityResource>(result.Resource);

            return Ok(xEntityResource);
        }

    }
}