using Klinika.Server.Services.DoktorService;
using Klinika.Shared;
using Klinika.Shared.Dto.DoktorDto;
using Microsoft.AspNetCore.Mvc;

namespace Klinika.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoktorController : ControllerBase
    {
        private readonly DoktorService _doktorService;

        public DoktorController(DoktorService doktorService)
        {
            _doktorService = doktorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoktori() 
        {
            var doktori = await _doktorService.GetDoktori();
            return Ok(doktori);
        }

        [HttpGet("{doktorId}")]
        public async Task<IActionResult> GetDoktorById(int doktorId)
        {
            var doktor = await _doktorService.GetDoktorById(doktorId);
            return Ok(doktor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoktor(DoktorCreateDto createDto)
        {
            var response = await _doktorService.CreateDoktor(createDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDoktor(DoktorUpdateDto updateDto)
        {
            var response = await _doktorService.UpdateDoktor(updateDto);
            return Ok(response);
        }

        [HttpDelete("{doktorId}")]
        public async Task<IActionResult> DeleteDoktor(int doktorId)
        {
            var response = await _doktorService.DeleteDoktor(doktorId);
            return Ok(response);
        }
    }
}
