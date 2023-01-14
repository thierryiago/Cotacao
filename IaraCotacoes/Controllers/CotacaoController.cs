using IaraCotacoes.Models;
using Microsoft.AspNetCore.Mvc;

namespace IaraCotacoes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CotacaoController : ControllerBase
    {

        private readonly ILogger<CotacaoController> _logger;

        [HttpGet]
        public IActionResult GetCotacao()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCotacaoById(Guid id)
        {
            var teste = "";
            if (teste != null)
                return Ok(teste);
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddCotacao()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCotacao(Guid id)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCotacao(Guid id)
        {
            return NoContent();
        }
    }
}