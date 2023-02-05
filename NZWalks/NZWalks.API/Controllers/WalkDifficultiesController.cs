using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Repostories;
using AutoMapper;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class WalkDifficultiesController : Controller
    {
        private readonly IWalkDifficultyRepository _walkDifficultyRepository;
        private readonly IMapper _mapper;

        public WalkDifficultiesController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
         this._walkDifficultyRepository = walkDifficultyRepository;
         this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalkDifficultiesAsync()
        {
            return Ok(await _walkDifficultyRepository.GetAllAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkDifficultiesAsync")]
        public async Task<IActionResult> GetWalkDifficultiesAsync(Guid id)
        {
            var walkDifficultyDomain = await _walkDifficultyRepository.GetAsync(id);

            var walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficulty>(walkDifficultyDomain);

            return Ok(walkDifficultyDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkDifficultyAsync(Models.Domain.WalkDifficulty walkDifficulty)
        {
            walkDifficulty = await _walkDifficultyRepository.AddAsync(walkDifficulty);
            return CreatedAtAction(nameof(GetWalkDifficultiesAsync), new { id = walkDifficulty.Id }, walkDifficulty);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWalkDifficultyAsync(Guid id)
        {
            var walkDifficulty = await _walkDifficultyRepository.DeleteAsync(id);

            if (walkDifficulty == null) return NotFound($"Cant find such a {id} ");

            var walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);

            return Ok(walkDifficultyDTO);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateWalkDifficultyAsync(Guid id, [FromBody]Models.Domain.WalkDifficulty walkDifficulty)
        {
            var updatedWalkDifficulty = await _walkDifficultyRepository.UpdateAsync(id, walkDifficulty);

            if (walkDifficulty == null) return NotFound($"Cant find such a {id} ");

            var walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficulty>(updatedWalkDifficulty);

            return Ok(walkDifficultyDTO);
        }
    }
}
