
using BlurTeknolojiBackendApp.DTO;
namespace BlurTeknolojiBackendApp.Services;

public interface IEnterpriseService
{
    Task<EnterpriseDto> CreateAsync(CreateEnterpriseDto  createEnterpriseDto);
    Task<UpdateEnterpriseDto> UpdateAsync(UpdateEnterpriseDto updateEnterpriseDto);
    Task<bool> DeleteAsync(Guid id);
    Task<EnterpriseDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<EnterpriseDto>> GetAllAsync();
}
