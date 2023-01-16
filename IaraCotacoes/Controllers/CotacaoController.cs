using IaraCotacoes.Data.Dtos.CotacaoDto;
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
        public async Task<IActionResult> GetAllCotacao()
        {
            var allCotacao = await _cotacaoService.GetAllCotacao();
            return Ok(allCotacao);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCotacaoByIdAsync(int id)
        {
            var cotacao = await _cotacaoService.GetCotacao(id);
            if (cotacao != null)
                return Ok(cotacao);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddCotacaoAsync([FromBody] CreateCotacaoDto cotacaoDto)
        {
            var resultCotacao = await _cotacaoService.AddCotacaoAsync(cotacaoDto);

            return CreatedAtAction(nameof(GetCotacaoByIdAsync), new { id = resultCotacao.Id }, cotacaoDto);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCotacaoAsync(int id, [FromBody] CreateCotacaoDto cotacaoDto)
        {
            var resultUpdate = await _cotacaoService.UpdateCotacao(id, cotacaoDto);
            if (resultUpdate.IsSuccess)
                return NoContent();
            return NotFound("Cotação não encontrada");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCotacaoAsync(int id)
        {
            var resultUpdate = await _cotacaoService.DeleteCotacao(id);
            if (resultUpdate.IsSuccess)
                return NoContent();
            return NotFound("Cotação não encontrada");
        }
    }
}