using Klinika.Server.Data;
using Klinika.Shared;
using Klinika.Shared.Dto.DoktorDto;
using Mapster;

namespace Klinika.Server.Services.DoktorService
{
    public class DoktorService : IDoktorService
    {
        private readonly DataContext _context;

        public DoktorService(DataContext context)
        {
            _context = context;
        }

        public async Task<DoktorDto> CreateDoktor(DoktorCreateDto createDoktorDto)
        {
            var doktor = createDoktorDto.Adapt<Doktor>();
            _context.Doktori.Add(doktor);
            await _context.SaveChangesAsync();

            return createDoktorDto.Adapt<DoktorDto>();
        }

        public async Task<bool> DeleteDoktor(int doktorId)
        {
            var check = await _context.Doktori.FindAsync(doktorId);
            if (check != null)
            {
                _context.Doktori.Remove(check);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<DoktorDto>GetDoktorById(int doktorId)
        {
            var doktor = await _context.Doktori.FindAsync(doktorId);
            return doktor.Adapt<DoktorDto>();
        }

        public async Task<List<DoktorDto>>GetDoktori()
        {
            var doktori = await _context.Doktori.ToListAsync();
            return doktori.Adapt<List<DoktorDto>>();
        }

        public async Task<DoktorDto> UpdateDoktor(DoktorUpdateDto updateDoktorDto)
        {
            var findDoktor = await _context.Doktori.FindAsync(updateDoktorDto.Id);
            var doktorForUpdate = updateDoktorDto.Adapt<Doktor>();
            findDoktor = doktorForUpdate;

            _context.Doktori.Update(findDoktor);
            await _context.SaveChangesAsync();
            return findDoktor.Adapt<DoktorDto>();
        }
    }
}
