using Klinika.Shared;
using Klinika.Shared.Dto.OdeljenjeDto;

namespace Klinika.Server.Services.OdeljenjeService
{
    public interface IOdeljenjeService
    {
        Task<List<OdeljenjeDto>> GetOdeljenja();
        Task<OdeljenjeDto> GetOdeljenjeById(int odeljenjeId);
        Task<OdeljenjeDto> CreateOdeljenje(OdeljenjeCreateDto createOdeljenjeDto);
        Task<OdeljenjeDto> UpdateOdeljenje(OdeljenjeUpdateDto updateOdeljenjeDto);
        Task<bool> DeleteOdeljenje(int odeljenjeId);
    }
}
