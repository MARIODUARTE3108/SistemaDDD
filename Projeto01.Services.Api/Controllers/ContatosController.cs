using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pojeto01.Application.Commands;
using Pojeto01.Application.Interfaces;

namespace Projeto01.Services.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly IContatoAppService _contatoAppService;

        public ContatosController(IContatoAppService contatoAppService)
        {
            _contatoAppService = contatoAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ContatoCreateCommand command)
        {
            try
            {
                var contato = await _contatoAppService.Create(command);
                return StatusCode(201, contato);
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Errors);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(ContatoUpdateCommand command)
        {
            try
            {
                var contato = await _contatoAppService.Update(command);
                return StatusCode(200, contato);
            }
            catch (ValidationException ex)
            {
                return StatusCode(400, ex.Errors);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var command = new ContatoDeleteCommand { Id = id };

                var contato = await _contatoAppService.Delete(command);
                return StatusCode(200, contato);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpGet("{page}/{limit}")]
        public IActionResult GetAll(int page, int limit)
        {
            try
            {
                var contatos = _contatoAppService.GetAll(page, limit);    
                if(contatos.Count == 0)
                    return NoContent();

                return StatusCode(200, contatos);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var contato = _contatoAppService.GetById(id);
                if (contato == null)
                    return NoContent();

                return StatusCode(200, contato);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, new { ex.Message });
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { ex.Message });
            }
        }
    }
}
