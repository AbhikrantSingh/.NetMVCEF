using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NzWalk.Models.DTO;
using NzWalk.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzWalk.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class RegionController : Controller
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegion()
        {
            var region = await _regionRepository.GetAllAsync();
            var regionDTO = _mapper.Map<List<Models.DTO.RegionDTO>>(region);
            return Ok(regionDTO);

        }
        [HttpGet]
        [ActionName("GetRegionAsync")]
        [Route("{id:guid}")]
        [Authorize(Roles = "reader")]

        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await _regionRepository.GetAsync(id);
            if (region == null)
                return NotFound();
            var regionDTO = _mapper.Map<Models.DTO.RegionDTO>(region);
            return Ok(regionDTO);
        }

        [HttpPost]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddRegionAsync(AddRegionRequest addRegionRequest)
        {

            //Valiade 
            //if(!ValidateAddRegion(addRegionRequest))
            //{
            //    return BadRequest(ModelState);
            //}

            var region = new Models.Domains.Region()
            {
                Code = addRegionRequest.Code,
                Area = addRegionRequest.Area,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Name = addRegionRequest.Name,
                population = addRegionRequest.population
            };

            var Newregion = await _regionRepository.AddAsync(region);
            var DTO = _mapper.Map<Models.DTO.RegionDTO>(Newregion);
            return CreatedAtAction(nameof(GetRegionAsync), new { id = DTO.Id }, DTO);

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid guid)
        {
            var region = await _regionRepository.DeleteAsync(guid);
            if (region == null)
                return NotFound();
            var DTO = _mapper.Map<Models.DTO.RegionDTO>(region);

            return Ok(region);

        }
        #region PrivateMethods
        private bool ValidateAddRegion(Models.DTO.AddRegionRequest addRegionRequest)
        {
            if (addRegionRequest == null)
                return false;
            if(string.IsNullOrEmpty(addRegionRequest.Code))
            {
                ModelState.AddModelError(nameof(addRegionRequest.Code), $"{addRegionRequest.Code} invalid");
            }
            if (string.IsNullOrEmpty(addRegionRequest.Name))
            {
                ModelState.AddModelError(nameof(addRegionRequest.Code), $"{addRegionRequest.Name} invalid");
            }
            if (ModelState.ErrorCount > 0)
                return false;
            return true;
        }
        #endregion
    }
}
