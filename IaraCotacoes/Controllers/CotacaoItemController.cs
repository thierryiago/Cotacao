using IaraCotacoes.Data.Dtos.CotacaoItemDto;
using IaraCotacoes.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IaraCotacoes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CotacaoItemController : ControllerBase
    {
        private readonly ILogger<CotacaoItemController> _logger;
        private readonly ICotacaoItemService _cotacaoItemService;

        public CotacaoItemController(ILogger<CotacaoItemController> logger, ICotacaoItemService cotacaoItemService)
        {
            _logger = logger;
            _cotacaoItemService = cotacaoItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCotacaoAsync()
        {
            var allCotacao = await _cotacaoItemService.GetAllCotacaoItem();
            return Ok(allCotacao);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCotacaoItemByIdAsync(int id)
        {
            var cotacao = await _cotacaoItemService.GetCotacaoItem(id);
            return cotacao.Id == 0 ? NotFound() : Ok(cotacao);
        }

        [HttpPost]
        public async Task<IActionResult> AddCotacaoItemAsync([FromBody] CreateCotacaoItemDto cotacaoItemDto)
        {
            var resultCotacaoItem = await _cotacaoItemService.AddCotacaoItemAsync(cotacaoItemDto);
            if (resultCotacaoItem != null)
            {
                cotacaoItemDto.Id = resultCotacaoItem.Id;
                return CreatedAtAction(nameof(GetCotacaoItemByIdAsync), new { resultCotacaoItem.Id }, cotacaoItemDto);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCotacaoAsync(int id, [FromBody] CreateCotacaoItemDto cotacaoDto)
        {
            var resultUpdate = await _cotacaoItemService.UpdateCotacaoItem(id, cotacaoDto);
            if (resultUpdate.IsSuccess)
                return NoContent();
            return NotFound("Item não encontrado");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCotacaoAsync(int id)
        {
            var resultUpdate = await _cotacaoItemService.DeleteCotacaoItem(id);
            if (resultUpdate.IsSuccess)
                return NoContent();
            return NotFound("Item não encontrado");
        }
    }
}
