using GraphQLDemo.DAL.Repositories.Interfaces;
using GraphQLDemo.Domain.DTO;
using GraphQLDemo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("account")]
        public async Task<IActionResult> CreateAccount([FromQuery] AccountCreateDTO accountDTO)
        {
            var entity = await _accountRepository.GetAsync().SingleOrDefaultAsync(x => x.Login == accountDTO.Login);
            if (entity == null)
            {
                entity = await _accountRepository.AddAsync(new Account(accountDTO));
                await _accountRepository.SaveAsync();

                if (entity != null)
                {

                    return Created("", entity);
                }

                return BadRequest();
            }

            return Conflict("account with this login alredy exist");

        }

        [HttpGet("accounts")]
        public async Task<IActionResult> GetAccounts()
        {
            var entites = await _accountRepository.GetAsync().ToArrayAsync();
            if (entites != null)
            {

                return Ok(entites);
            }

            return NotFound();
        }

        [HttpGet("accountId")]
        public async Task<IActionResult> GetAccountById([FromQuery] Guid id)
        {
            var entity = await _accountRepository.GetAsync().SingleOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {

                return Ok(entity);
            }

            return NotFound();
        }

        [HttpGet("accountLogin")]
        public async Task<IActionResult> GetAccountByLogin([FromQuery] string login)
        {
            var entity = await _accountRepository.GetAsync().SingleOrDefaultAsync(x => x.Login == login);
            if (entity != null)
            {

                return Ok(entity);
            }

            return NotFound();
        }

        [HttpDelete("account")]
        public async Task<IActionResult> DeleteAccountByLogin([FromQuery] string login)
        {
            var entity = await _accountRepository.GetAsync().SingleOrDefaultAsync(x => x.Login == login);
            if (entity != null)
            {
                _accountRepository.Delete(entity);
                await _accountRepository.SaveAsync();

                return NoContent();
            }

            return NotFound();
        }

    }
}