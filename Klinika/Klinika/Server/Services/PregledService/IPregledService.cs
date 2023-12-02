using Klinika.Shared;
using Klinika.Shared.Dto.PregledDto;

namespace Klinika.Server.Services.PregledService
{
    public interface IPregledService
    {
        Task<List<PregledDto>> GetPregledi();
        Task<PregledDto> GetPregledById(int pregledId);
        Task<PregledDto> CreatePregled(PregledCreateDto pregledCreateDto);
        Task<PregledDto> UpdatePregled(PregledUpdateDto pregledCreateDto);
        Task<bool> DeletePregled(int pregledId);
    }
}
