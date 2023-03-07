using AutoMapper;
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
    public class WalkController : Controller
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;
        public WalkController(IWalkRepository walkRepository, IMapper mapper)
        {
            _walkRepository = walkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegionAsync()
        {
            var walks = await _walkRepository.GetAllAsync();
            var walkDTOs = _mapper.Map<List<Models.DTO.WalkDTO>>(walks);
            return Ok(walkDTOs);

        }
        [HttpGet]
        [ActionName("GetRegionAsync")]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await _walkRepository.GetAsync(id);
            if (region == null)
                return NotFound();
            var regionDTO = _mapper.Map<Models.DTO.RegionDTO>(region);
            return Ok(regionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkAsync([FromBody]AddWalkRequest addWalkRequest)
        {
            var walk = new Models.Domains.Walk()
            {
                Length = addWalkRequest.Length,
                Name = addWalkRequest.Name,
                RegionId = addWalkRequest.RegionId,
                WalkDiffcultyId = addWalkRequest.WalkDiffcultyId
            };

            var newWalk = await _walkRepository.AddAsync(walk) ;
            var DTO = _mapper.Map<Models.DTO.RegionDTO>(newWalk);
            return CreatedAtAction(nameof(GetRegionAsync), new { id = DTO.Id }, DTO);

        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid guid)
        {
            var region = await _walkRepository.DeleteAsync(guid);
            if (region == null)
                return NotFound();
            var DTO = _mapper.Map<Models.DTO.RegionDTO>(region);

            return Ok(region);

        }
    }
}
