using Klinika.Shared;
using Klinika.Shared.Dto.DoktorDto;


namespace Klinika.Server.Services.DoktorService
{
    public interface IDoktorService
    {
        Task<List<DoktorDto>> GetDoktori();
        Task<DoktorDto> GetDoktorById(int doktorId);
        Task<DoktorDto> CreateDoktor(DoktorCreateDto createDoktorDto);
        Task<DoktorDto> UpdateDoktor(DoktorUpdateDto updateDoktorDto);
        Task<bool>DeleteDoktor(int doktorId);
    }
}
