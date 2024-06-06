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
    public class InventoryController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryController(IMapper mapper, IInventoryRepository inventoryRepository)
        {
            _mapper = mapper;
            _inventoryRepository = inventoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listInventory = await _inventoryRepository.GetListInventory();

                var listInventoryDto = _mapper.Map<IEnumerable<InventoryDTO>>(listInventory);

                return Ok(listInventoryDto);
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
                var inventory = await _inventoryRepository.GetInventory(id);

                if (inventory == null)
                {
                    return NotFound();
                }

                var inventoryDto = _mapper.Map<InventoryDTO>(inventory);

                return Ok(inventoryDto);

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
                var inventory = await _inventoryRepository.GetInventory(id);

                if (inventory == null)
                {
                    return NotFound();
                }

                await _inventoryRepository.DeleteInventory(inventory);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(InventoryDTO inventoryDto)
        {
            try
            {
                var inventory = _mapper.Map<Inventory>(inventoryDto);

                inventory.CreatedDate = DateTime.Now;

                inventory = await _inventoryRepository.AddInventory(inventory);

                var inventoryItemDto = _mapper.Map<InventoryDTO>(inventory);

                return CreatedAtAction("Get", new { id = inventoryItemDto.Id }, inventoryItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, InventoryDTO inventoryDto)
        {
            try
            {
                var inventory = _mapper.Map<Inventory>(inventoryDto);

                if (id != inventory.Id)
                {
                    return BadRequest();
                }

                var inventoryItem = await _inventoryRepository.GetInventory(id);

                if (inventoryItem == null)
                {
                    return NotFound();
                }

                await _inventoryRepository.UpdateInventory(inventory);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
