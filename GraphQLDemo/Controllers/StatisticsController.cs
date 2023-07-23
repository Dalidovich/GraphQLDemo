using GraphQLDemo.DAL.Repositories.Interfaces;
using GraphQLDemo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharpCompress.Common;

namespace GraphQLDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public StatisticsController(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        [HttpPost("statistics")]
        public async Task<IActionResult> CreateStatistics([FromQuery] Statistics statistics)
        {
            var entity = await _statisticsRepository.AddAsync(statistics);
            await _statisticsRepository.SaveAsync();

            if (entity != null)
            {

                return Created("", entity);
            }

            return BadRequest();
        }

        [HttpGet("statistics")]
        public async Task<IActionResult> GetStatistics()
        {
            var entites = await _statisticsRepository.GetAsync().ToArrayAsync();
            if (entites != null)
            {

                return Ok(entites);
            }

            return NotFound();
        }

        [HttpDelete("statistics")]
        public async Task<IActionResult> DeleteStatistics([FromQuery] Guid id)
        {
            var entity = await _statisticsRepository.GetAsync().SingleOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                _statisticsRepository.Delete(entity);
                await _statisticsRepository.SaveAsync();

                return NoContent();
            }

            return NotFound();
        }

    }
}