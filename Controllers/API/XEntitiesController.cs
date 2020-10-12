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
    public class XEntitiesController: ControllerBase
    {
        
        private readonly IXEntityService _xEntityService;
        private readonly IMapper _mapper;

        public XEntitiesController(IXEntityService xEntityService, IMapper mapper)
        {
            _xEntityService = xEntityService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<XEntityResource>> GetAllAsync()
        {
            var XEntities = await _xEntityService.ListAsync();
            var resources = _mapper.Map<IEnumerable<XEntity>,IEnumerable<XEntityResource>>(XEntities);
            return resources;
        }
        // [HttpGet("{id}")]
        // public async Task<IActionResult> FindByIdXEntityAsync(int id)
        // {
        //     var xEntityResource = await _xEntityService.FindByIdAsync(id);
        //     return Ok(xEntityResource);
        // }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveXEntityResource resource)
        {
            if (false == ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var xEntity = _mapper.Map<SaveXEntityResource, XEntity>(resource);
            var xEntityResource = await _xEntityService.SaveAsync(xEntity);
            return Ok(xEntityResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveXEntityResource resource)
        {
            if (false == ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            var xEntity = _mapper.Map<SaveXEntityResource, XEntity>(resource);
            var result = await _xEntityService.UpdateAsync(id, xEntity);

            if (false == result.Success)
            {
                return BadRequest(result.Message);
            }

            var xEntityResource = _mapper.Map<XEntity, XEntityResource>(result.XEntity);

            return Ok(xEntityResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _xEntityService.DeleteAsync(id);

            if (false == result.Success)
            {
                return BadRequest(result.Message);
            }

            var xEntityResource = _mapper.Map<XEntity, XEntityResource>(result.XEntity);

            return Ok(xEntityResource);
        }

    }
}