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
    public class CropController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ICropRepository _cropRepository;

        public CropController(IMapper mapper, ICropRepository cropRepository)
        {
            _mapper = mapper;
            _cropRepository = cropRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCrops = await _cropRepository.GetListCrops();

                var listCropsDto = _mapper.Map<IEnumerable<CropDTO>>(listCrops);

                return Ok(listCropsDto);
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
                var crop = await _cropRepository.GetCrop(id);

                if (crop == null)
                {
                    return NotFound();
                }

                var cropDto = _mapper.Map<CropDTO>(crop);

                return Ok(cropDto);

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
                var crop = await _cropRepository.GetCrop(id);

                if (crop == null)
                {
                    return NotFound();
                }

                await _cropRepository.DeleteCrop(crop);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CropDTO cropDto)
        {
            try
            {
                var crop = _mapper.Map<Crop>(cropDto);

                crop.CreatedDate = DateTime.Now;

                crop = await _cropRepository.AddCrop(crop);

                var cropItemDto = _mapper.Map<CropDTO>(crop);

                return CreatedAtAction("Get", new { id = cropItemDto.Id }, cropItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CropDTO cropDto)
        {
            try
            {
                var crop = _mapper.Map<Crop>(cropDto);

                if (id != crop.Id)
                {
                    return BadRequest();
                }

                var cropItem = await _cropRepository.GetCrop(id);

                if (cropItem == null)
                {
                    return NotFound();
                }

                await _cropRepository.UpdateCrop(crop);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
