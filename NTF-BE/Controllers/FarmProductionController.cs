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
    public class FarmProductionController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IFarmProductionRepository _farmProductionRepository;

        public FarmProductionController(IMapper mapper, IFarmProductionRepository farmProductionRepository)
        {
            _mapper = mapper;
            _farmProductionRepository = farmProductionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listFarmProductions = await _farmProductionRepository.GetListFarmProductions();

                var listFarmProductionsDto = _mapper.Map<IEnumerable<FarmProductionDTO>>(listFarmProductions);

                return Ok(listFarmProductionsDto);
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
                var farmProduction = await _farmProductionRepository.GetFarmProduction(id);

                if (farmProduction == null)
                {
                    return NotFound();
                }

                var FarmProductionDTO = _mapper.Map<FarmProductionDTO>(farmProduction);

                return Ok(FarmProductionDTO);

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
                var farmProduction = await _farmProductionRepository.GetFarmProduction(id);

                if (farmProduction == null)
                {
                    return NotFound();
                }

                await _farmProductionRepository.DeleteFarmProduction(farmProduction);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(FarmProductionDTO FarmProductionDTO)
        {
            try
            {
                var farmProduction = _mapper.Map<FarmProduction>(FarmProductionDTO);

                farmProduction.CreatedDate = DateTime.Now;

                farmProduction = await _farmProductionRepository.AddFarmProduction(farmProduction);

                var farmProductionItemDto = _mapper.Map<FarmProductionDTO>(farmProduction);

                return CreatedAtAction("Get", new { id = farmProductionItemDto.Id }, farmProductionItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, FarmProductionDTO FarmProductionDTO)
        {
            try
            {
                var farmProduction = _mapper.Map<FarmProduction>(FarmProductionDTO);

                if (id != farmProduction.Id)
                {
                    return BadRequest();
                }

                var farmProductionItem = await _farmProductionRepository.GetFarmProduction(id);

                if (farmProductionItem == null)
                {
                    return NotFound();
                }

                await _farmProductionRepository.UpdateFarmProduction(farmProduction);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
