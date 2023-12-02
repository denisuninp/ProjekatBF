using Klinika.Server.Services.DoktorService;
using Klinika.Server.Services.OdeljenjeService;
using Klinika.Shared;
using Klinika.Shared.Dto.OdeljenjeDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Klinika.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdeljenjeController : ControllerBase
    {
        private readonly OdeljenjeService _odeljenjeService;

        public OdeljenjeController(OdeljenjeService odeljenjeService)
        {
            _odeljenjeService = odeljenjeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetOdeljenja()
        {
            var odeljenja = await _odeljenjeService.GetOdeljenja();
            return Ok(odeljenja);
        }
        [HttpGet("{odeljenjeId}")]
        public async Task<IActionResult> GetOdeljenjeById(int odeljenjeId)
        {
            var odeljenje = await _odeljenjeService.GetOdeljenjeById(odeljenjeId);
            return Ok(odeljenje);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOdeljenje(OdeljenjeCreateDto createDto)
        {
            var response = await _odeljenjeService.CreateOdeljenje(createDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOdeljenje(OdeljenjeUpdateDto updateDto)
        {
            var response = await _odeljenjeService.UpdateOdeljenje(updateDto);
            return Ok(response);
        }

        [HttpDelete("{odeljenjeId}")]
        public async Task<IActionResult> DeleteOdeljenje(int odeljenjeId)
        {
            var response = await _odeljenjeService.DeleteOdeljenje(odeljenjeId);
            return Ok(response);
        }
    }
}
