using Klinika.Server.Data;
using Klinika.Shared;
using Klinika.Shared.Dto.DoktorDto;
using Klinika.Shared.Dto.OdeljenjeDto;
using Mapster;

namespace Klinika.Server.Services.OdeljenjeService
{
    public class OdeljenjeService : IOdeljenjeService
    {
        private readonly DataContext _context;

        public OdeljenjeService(DataContext context)
        {
            _context = context;
        }

        public async Task<OdeljenjeDto> CreateOdeljenje(OdeljenjeCreateDto createOdeljenjeDto)
        {
            var odeljenje = createOdeljenjeDto.Adapt<Odeljenje>();
            _context.Odeljenja.Add(odeljenje);
            await _context.SaveChangesAsync();

            return createOdeljenjeDto.Adapt<OdeljenjeDto>();
        }

        public async Task<bool> DeleteOdeljenje(int odeljenjeId)
        {
            var check = await _context.Odeljenja.FindAsync(odeljenjeId);
            if (check != null)
            {
                _context.Odeljenja.Remove(check);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<OdeljenjeDto> GetOdeljenjeById(int odeljenjeId)
        {
            var odeljenje = await _context.Odeljenja.FindAsync(odeljenjeId);
            return odeljenje.Adapt<OdeljenjeDto>();
        }

        public async Task<List<OdeljenjeDto>> GetOdeljenja()
        {
            var odeljenja = await _context.Odeljenja.ToListAsync();
            return odeljenja.Adapt<List<OdeljenjeDto>>();
        }

        public async Task<OdeljenjeDto> UpdateOdeljenje(OdeljenjeUpdateDto updateOdeljenjeDto)
        {
            var findOdeljenje = await _context.Odeljenja.FindAsync(updateOdeljenjeDto.Id);
            var odeljenjeForUpdate = updateOdeljenjeDto.Adapt<Odeljenje>();
            findOdeljenje = odeljenjeForUpdate;

            _context.Odeljenja.Update(findOdeljenje);
            await _context.SaveChangesAsync();
            return findOdeljenje.Adapt<OdeljenjeDto>();
        }
    }
}
