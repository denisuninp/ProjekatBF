using Klinika.Shared;
using Klinika.Shared.Dto.PacijentDto;

namespace Klinika.Server.Services.PacijentService
{
    public interface IPacijentService
    {
        Task<List<PacijentDto>> GetPacijenti();
        Task<PacijentDto> GetPacijentById(int pacijentId);
        Task<PacijentDto> CreatePacijent(PacijentCreateDto PacijentCreateDto);
        Task<PacijentDto> UpdatePacijent(PacijentUpdateDto updatePacijentDto);
        Task<bool> DeletePacijent(int pacijentId);
    }
}
