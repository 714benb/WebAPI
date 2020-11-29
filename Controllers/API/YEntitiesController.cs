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
    [Produces("application/json")]
    [ApiController]
    public class YEntitiesController: ControllerBase
    {
        
        private readonly IYEntitieservice _YEntitieservice;
        private readonly IMapper _mapper;

        public YEntitiesController(IYEntitieservice YEntitieservice, IMapper mapper)
        {
            _YEntitieservice = YEntitieservice;
            _mapper = mapper;
        }

        /// <summary>
        /// List all the yEntities;
        /// </summary>
        /// <returns>
        /// an enumerable list of yEntities;
        /// </returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<YEntityResource>), 200)]
        public async Task<IEnumerable<YEntityResource>> GetAllAsync()
        {
            var XEntities = await _YEntitieservice.ListAsync();
            var resources = _mapper.Map<IEnumerable<YEntity>, IEnumerable<YEntityResource>>(XEntities);
            return resources;
        }

        /// <summary>
        /// Saves/Creates a new yEntity.
        /// </summary>
        /// <param name="resource">The yEntity data</param>
        /// <returns>
        /// A response that indicates failure (400) or success (201) and the yEntity data
        /// </returns>
        [HttpPost]
        [ProducesResponseType(typeof(YEntityResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveYEntityResource resource)
        {
            var yEntity = _mapper.Map<SaveYEntityResource, YEntity>(resource);
            var result = await _YEntitieservice.SaveAsync(yEntity);
            if (false == result.Success)
            {
                return BadRequest(result.Message);
            }

            var yEntityResource = _mapper.Map<YEntity, YEntityResource>(result.Resource);
            return Ok(yEntityResource);
        }

        /// <summary>
        /// Updates and existing yEntity if one exist for the given identifier
        /// </summary>
        /// <param name="id">The yEntity identifier</param>
        /// <param name="resource">The data to be used for the update.</param>
        /// <returns>
        /// A response that indicates failure (400) or success (200) and the yEntity data
        /// </returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(YEntityResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveYEntityResource resource)
        {
            var yEntity = _mapper.Map<SaveYEntityResource, YEntity>(resource);
            var result = await _YEntitieservice.UpdateAsync(id, yEntity);

            if (false == result.Success)
            {
                return BadRequest(result.Message);
            }

            var yEntityResource = _mapper.Map<YEntity, YEntityResource>(result.Resource);
            return Ok(yEntityResource);
        }

        /// <summary>
        /// Delete the yEntity if found by the given identifier
        /// </summary>
        /// <param name="id">The yEntity identifier</param>
        /// <returns>
        /// A response that indicates failure (400) or success (200) and the yEntity data
        /// </returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(YEntityResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _YEntitieservice.DeleteAsync(id);

            if (false == result.Success)
            {
                return BadRequest(result.Message);
            }

            var yEntityResource = _mapper.Map<YEntity, YEntityResource>(result.Resource);
            return Ok(yEntityResource);
        }

    }
}