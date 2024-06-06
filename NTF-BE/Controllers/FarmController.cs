using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using NTF_BE.Models;
using NTF_BE.Models.DTO;
using NTF_BE.Models.Repository;

namespace NTF_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IFarmRepository _farmRepository;

        public FarmController(IMapper mapper, IFarmRepository farmRepository)
        {
            _mapper = mapper;
            _farmRepository = farmRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listFarms = await _farmRepository.GetListFarms();

                var listFarmsDto = _mapper.Map<IEnumerable<FarmDTO>>(listFarms);

                return Ok(listFarmsDto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var farm = await _farmRepository.GetFarm(id);

                if (farm == null)
                {
                    return NotFound();
                }

                var farmDto = _mapper.Map<FarmDTO>(farm);

                return Ok(farmDto);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var farm = await _farmRepository.GetFarm(id);

                if (farm == null)
                {
                    return NotFound();
                }

                await _farmRepository.DeleteFarm(farm);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(FarmDTO farmDto)
        {
            try
            {
                var farm = _mapper.Map<Farm>(farmDto);

                farm.CreatedDate = DateTime.Now;

                farm = await _farmRepository.AddFarm(farm);

                var farmItemDto = _mapper.Map<FarmDTO>(farm);

                return CreatedAtAction("Get", new { id = farmItemDto.Id }, farmItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, FarmDTO farmDto)
        {
            try
            {
                var farm = _mapper.Map<Farm>(farmDto);

                if (id != farm.Id)
                {
                    return BadRequest();
                }

                var farmItem = await _farmRepository.GetFarm(id);

                if (farmItem == null)
                {
                    return NotFound();
                }

                await _farmRepository.UpdateFarm(farm);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
