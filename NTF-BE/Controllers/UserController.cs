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
    public class UserController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listUsers = await _userRepository.GetListUsers();

                var listUsersDto = _mapper.Map<IEnumerable<UserDTO>>(listUsers);

                return Ok(listUsersDto);
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
                var user = await _userRepository.GetUser(id);

                if (user == null)
                {
                    return NotFound();
                }

                var userDto = _mapper.Map<UserDTO>(user);

                return Ok(userDto);

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
                var user = await _userRepository.GetUser(id);

                if (user == null)
                {
                    return NotFound();
                }

                await _userRepository.DeleteUser(user);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDTO userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);

                user.CreatedDate = DateTime.Now;

                user = await _userRepository.AddUser(user);

                var userItemDto = _mapper.Map<UserDTO>(user);

                return CreatedAtAction("Get", new { id = userItemDto.Id }, userItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UserDTO userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);

                if (id != user.Id)
                {
                    return BadRequest();
                }

                var userItem = await _userRepository.GetUser(id);

                if (userItem == null)
                {
                    return NotFound();
                }

                await _userRepository.UpdateUser(user);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
