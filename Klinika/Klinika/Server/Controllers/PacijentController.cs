using Klinika.Server.Services.DoktorService;
using Klinika.Server.Services.PacijentService;
using Klinika.Shared;
using Klinika.Shared.Dto.DoktorDto;
using Klinika.Shared.Dto.PacijentDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Klinika.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacijentController : ControllerBase
    {
        private readonly PacijentService _pacijentService;

        public PacijentController(PacijentService pacijentService)
        {
            _pacijentService = pacijentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPacijenti()
        {
            var pacijenti = await _pacijentService.GetPacijenti();
            return Ok(pacijenti);
        }

        [HttpGet("{pacijentId}")]
        public async Task<IActionResult> GetPacijentById(int pacijentId)
        {
            var pacijent = await _pacijentService.GetPacijentById(pacijentId);
            return Ok(pacijent);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePacijent(PacijentCreateDto createDto)
        {
            var response = await _pacijentService.CreatePacijent(createDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePacijent(PacijentUpdateDto updateDto)
        {
            var response = await _pacijentService.UpdatePacijent(updateDto);
            return Ok(response);
        }

        [HttpDelete("{pacijentId}")]
        public async Task<IActionResult> DeletePacijent(int pacijentId)
        {
            var response = await _pacijentService.DeletePacijent(pacijentId);
            return Ok(response);
        }
    }
}
