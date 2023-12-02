using Klinika.Server.Services.PregledService;
using Klinika.Shared;
using Klinika.Shared.Dto.DoktorDto;
using Klinika.Shared.Dto.PregledDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Klinika.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PregledController : ControllerBase
    {
        private readonly PregledService _pregledService;

        public PregledController(PregledService pregledService)
        {
            _pregledService = pregledService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPregledi()
        {
            var pregledi = await _pregledService.GetPregledi();
            return Ok(pregledi);
        }

        [HttpGet("{pregledId}")]
        public async Task<IActionResult> GetPregledById(int pregledId)
        {
            var pregled = await _pregledService.GetPregledById(pregledId);
            return Ok(pregled);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePregled(PregledCreateDto createDto)
        {
            var response = await _pregledService.CreatePregled(createDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePregled(PregledUpdateDto updateDto)
        {
            var response = await _pregledService.UpdatePregled(updateDto);
            return Ok(response);
        }

        [HttpDelete("{pregledId}")]
        public async Task<IActionResult> DeletePregled(int pregledId)
        {
            var response = await _pregledService.DeletePregled(pregledId);
            return Ok(response);
        }
    }
}
