using IaraCotacoes.Models;
using IaraCotacoes.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IaraCotacoes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CotacaoController : ControllerBase
    {

        private readonly ILogger<CotacaoController> _logger;
        private readonly ICotacaoService _cotacaoService;

        public CotacaoController(ILogger<CotacaoController> logger, ICotacaoService cotacaoService)
        {
            _logger = logger;
            _cotacaoService = cotacaoService;
        }

        [HttpGet]
        public IActionResult GetAllCotacao()
        {
            var allCotacao = _cotacaoService.GetAllCotacao();
            return Ok(allCotacao);
        }

        [HttpGet("{id}")]
        public IActionResult GetCotacaoById(Guid id)
        {
            var cotacao = _cotacaoService.GetCotacao(id);
            if (cotacao != null)
                return Ok(cotacao);
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