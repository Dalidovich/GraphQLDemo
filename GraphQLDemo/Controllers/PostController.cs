using GraphQLDemo.DAL.Repositories.Interfaces;
using GraphQLDemo.Domain.DTO;
using GraphQLDemo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpPost("post")]
        public async Task<IActionResult> CreatePost([FromQuery] PostCreateDTO post)
        {
            var entity = await _postRepository.AddAsync(new Post(post));
            if (entity != null)
            {

                return Created("", entity);
            }

            return BadRequest();

        }

        [HttpGet("post")]
        public async Task<IActionResult> GetAccountById([FromQuery] string id)
        {
            var entity = _postRepository.GetAsync().SingleOrDefault(x => x.Id == id);
            if (entity != null)
            {

                return Ok(entity);
            }

            return NotFound();
        }

        [HttpGet("posts")]
        public async Task<IActionResult> GetPosts()
        {
            var entites = _postRepository.GetAsync();
            if (entites != null)
            {

                return Ok(entites);
            }

            return NotFound();
        }

        [HttpDelete("post")]
        public async Task<IActionResult> DeleteAccountByLogin([FromQuery] string id)
        {
            var entity = _postRepository.GetAsync().SingleOrDefault(x => x.Id == id);
            if (entity != null)
            {
                await _postRepository.DeleteAsync(x => x.Id == id);

                return NoContent();
            }

            return NotFound();
        }
    }
}