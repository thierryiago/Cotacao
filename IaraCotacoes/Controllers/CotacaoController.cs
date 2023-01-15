using IaraCotacoes.Data.Dtos.Cotacao;
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
        public IActionResult GetCotacaoById(int id)
        {
            var cotacao = _cotacaoService.GetCotacao(id);
            if (cotacao != null)
                return Ok(cotacao);
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddCotacaoAsync([FromBody] CreateCotacaoDto cotacaoDto)
        {
            var resultCotacao = _cotacaoService.AddCotacaoAsync(cotacaoDto);
            if (resultCotacao != null)
            {
                return CreatedAtAction(nameof(GetCotacaoById), new { resultCotacao.Id }, cotacaoDto);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCotacao(int id, [FromBody] CreateCotacaoDto cotacaoDto)
        {
            var resultUpdate = _cotacaoService.UpdateCotacao(id, cotacaoDto);
            if(resultUpdate.Result.IsSuccess)
                return NoContent();
            return NotFound("Cotação não encontrada");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCotacao(int id)
        {
            var resultUpdate = _cotacaoService.DeleteCotacao(id);
            if (resultUpdate.Result.IsSuccess)
                return NoContent();
            return NotFound("Cotação não encontrada");
        }
    }
}