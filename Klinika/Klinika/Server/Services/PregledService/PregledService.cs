using Klinika.Server.Data;
using Klinika.Shared;
using Klinika.Shared.Dto.DoktorDto;
using Klinika.Shared.Dto.PregledDto;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Klinika.Server.Services.PregledService
{
    public class PregledService : IPregledService
    {
        private readonly DataContext _context;
        public PregledService(DataContext context)
        {
            _context = context;
        }
        public async Task<PregledDto> CreatePregled(PregledCreateDto createPregledDto)
        {
            var pregled = createPregledDto.Adapt<Pregled>();
            _context.Pregledi.Add(pregled);
            await _context.SaveChangesAsync();

            return createPregledDto.Adapt<PregledDto>();
        }

        public async Task<bool> DeletePregled(int pregledId)
        {
            var check = await _context.Pregledi.FindAsync(pregledId);
            if (check != null)
            {
                _context.Pregledi.Remove(check);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<PregledDto> GetPregledById(int pregledId)
        {
            var pregled = await _context.Pregledi.FindAsync(pregledId);
            return pregled.Adapt<PregledDto>();
        }

        public async Task<List<PregledDto>> GetPregledi()
        {
            var pregledi = await _context.Pregledi.ToListAsync();
            return pregledi.Adapt<List<PregledDto>>();
        }

        public async Task<PregledDto> UpdatePregled(PregledUpdateDto updatePregledDto)
        {
            var findPregled = await _context.Pregledi.FindAsync(updatePregledDto.Id);
            var pregledForUpdate = updatePregledDto.Adapt<Pregled>();
            findPregled = pregledForUpdate;

            _context.Pregledi.Update(findPregled);
            await _context.SaveChangesAsync();
            return findPregled.Adapt<PregledDto>();
        }
    }
}
