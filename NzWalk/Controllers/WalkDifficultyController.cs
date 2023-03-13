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
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficultyRepository _walkDifficultyRepos;
        private readonly IMapper _mapper;
        public WalkDifficultyController(IWalkDifficultyRepository walkRepository, IMapper mapper)
        {
            _walkDifficultyRepos = walkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegionAsync()
        {
            var walks = await _walkDifficultyRepos.GetAllAsync();
            var walkDTOs = _mapper.Map<List<Models.DTO.WalkDTO>>(walks);
            return Ok(walkDTOs);

        }
        [HttpGet]
        [ActionName("GetWalkDiffAsync")]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWalkDiffAsync(Guid id)
        {
            var walkDifficulty = await _walkDifficultyRepos.GetAsync(id);
            if (walkDifficulty == null)
                return NotFound();
            var walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficultyDTO>(walkDifficulty);
            return Ok(walkDifficultyDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkAsync([FromBody] AddWalkDiffcultyRequest addWalkRequest)
        {
            var walkD = new Models.Domains.WalkDifficulty()
            {
                Code = addWalkRequest.Code
            };

            var newWalkD = await _walkDifficultyRepos.AddAsync(walkD) ;
            var DTO = _mapper.Map<Models.DTO.RegionDTO>(newWalkD);
            return CreatedAtAction(nameof(GetWalkDiffAsync), new { id = DTO.Id }, DTO);

        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid guid)
        {
            var walkD = await _walkDifficultyRepos.DeleteAsync(guid);
            if (walkD == null)
                return NotFound();
            var DTO = _mapper.Map<Models.DTO.RegionDTO>(walkD);

            return Ok(walkD);

        }
    }
}
