using Microsoft.AspNetCore.Mvc;

namespace IaraCotacoes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CotacaoItemController : ControllerBase
    {
        private readonly ILogger<CotacaoController> _logger;

        [HttpGet]
        public IActionResult GetCotacaoItem()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCotacaoItemById(Guid id)
        {
            var teste = "";
            if (teste != null)
                return Ok(teste);
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddCotacaoItem()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCotacaoItem(Guid id)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCotacaoItem(Guid id)
        {
            return NoContent();
        }
    }
}
