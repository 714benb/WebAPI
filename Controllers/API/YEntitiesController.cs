using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Services;
using Supermarket.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Supermarket.API.Resources;
using Supermarket.API.Extensions;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class YEntitiesController: ControllerBase
    {
        
        private readonly IYEntitieservice _YEntitieservice;
        private readonly IMapper _mapper;

        public YEntitiesController(IYEntitieservice YEntitieservice, IMapper mapper)
        {
            _YEntitieservice = YEntitieservice;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<YEntityResource>> GetAllAsync()
        {
            var XEntities = await _YEntitieservice.ListAsync();
            var resources = _mapper.Map<IEnumerable<YEntity>,IEnumerable<YEntityResource>>(XEntities);
            return resources;
        }
        // [HttpGet("{id}")]
        // public async Task<IActionResult> FindByIdYEntityAsync(int id)
        // {
        //     var yEntityResource = await _YEntitieservice.FindByIdAsync(id);
        //     return Ok(yEntityResource);
        // }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveYEntityResource resource)
        {
            if (false == ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var yEntity = _mapper.Map<SaveYEntityResource, YEntity>(resource);
            var yEntityResource = await _YEntitieservice.SaveAsync(yEntity);
            return Ok(yEntityResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveYEntityResource resource)
        {
            if (false == ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var yEntity = _mapper.Map<SaveYEntityResource, YEntity>(resource);
            var result = await _YEntitieservice.UpdateAsync(id, yEntity);

            if (false == result.Success)
            {
                return BadRequest(result.Message);
            }

            var yEntityResource = _mapper.Map<YEntity, YEntityResource>(result.YEntity);

            return Ok(yEntityResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _YEntitieservice.DeleteAsync(id);

            if (false == result.Success)
            {
                return BadRequest(result.Message);
            }

            var yEntityResource = _mapper.Map<YEntity, YEntityResource>(result.YEntity);

            return Ok(yEntityResource);
        }

    }
}