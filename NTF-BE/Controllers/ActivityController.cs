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
    public class ActivityController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IActivityRepository _activityRepository;

        public ActivityController(IMapper mapper, IActivityRepository activityRepository)
        {
            _mapper = mapper;
            _activityRepository = activityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listActivities = await _activityRepository.GetListActivities();

                var listActivitiesDto = _mapper.Map<IEnumerable<ActivityDTO>>(listActivities);

                return Ok(listActivitiesDto);
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
                var activity = await _activityRepository.GetActivity(id);

                if (activity == null)
                {
                    return NotFound();
                }

                var activityDto = _mapper.Map<ActivityDTO>(activity);

                return Ok(activityDto);

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
                var activity = await _activityRepository.GetActivity(id);

                if (activity == null)
                {
                    return NotFound();
                }

                await _activityRepository.DeleteActivity(activity);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ActivityDTO activityDto)
        {
            try
            {
                var activity = _mapper.Map<Activity>(activityDto);

                activity.CreatedDate = DateTime.Now;

                activity = await _activityRepository.AddActivity(activity);

                var activityItemDto = _mapper.Map<ActivityDTO>(activity);

                return CreatedAtAction("Get", new { id = activityItemDto.Id }, activityItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ActivityDTO activityDto)
        {
            try
            {
                var activity = _mapper.Map<Activity>(activityDto);

                if (id != activity.Id)
                {
                    return BadRequest();
                }

                var activityItem = await _activityRepository.GetActivity(id);

                if (activityItem == null)
                {
                    return NotFound();
                }

                await _activityRepository.UpdateActivity(activity);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
