using Klinika.Server.Data;
using Klinika.Shared;
using Klinika.Shared.Dto.DoktorDto;
using Klinika.Shared.Dto.PacijentDto;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Klinika.Server.Services.PacijentService
{
    public class PacijentService : IPacijentService
    {
        private readonly DataContext _context;
        public PacijentService(DataContext context)
        {
            _context = context;
        }
        public async Task<PacijentDto> CreatePacijent(PacijentCreateDto createPacijentDto)
        {
            var pacijent = createPacijentDto.Adapt<Pacijent>();
            _context.Pacijenti.Add(pacijent);
            await _context.SaveChangesAsync();

            return createPacijentDto.Adapt<PacijentDto>();
        }

        public async Task<bool> DeletePacijent(int pacijentId)
        {
            var check = await _context.Pacijenti.FindAsync(pacijentId);
            if (check != null)
            {
                _context.Pacijenti.Remove(check);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<PacijentDto> GetPacijentById(int pacijentId)
        {
            var pacijent = await _context.Pacijenti.FindAsync(pacijentId);
            return pacijent.Adapt<PacijentDto>();
        }

        public async Task<List<PacijentDto>> GetPacijenti()
        {
            var pacijenti = await _context.Pacijenti.ToListAsync();
            return pacijenti.Adapt<List<PacijentDto>>();
        }

        public async Task<PacijentDto> UpdatePacijent(PacijentUpdateDto updatePacijentDto)
        {
            var findPacijent = await _context.Pacijenti.FindAsync(updatePacijentDto.Id);
            var pacijentForUpdate = updatePacijentDto.Adapt<Pacijent>();
            findPacijent = pacijentForUpdate;

            _context.Pacijenti.Update(findPacijent);
            await _context.SaveChangesAsync();
            return findPacijent.Adapt<PacijentDto>();
        }
    }
}
