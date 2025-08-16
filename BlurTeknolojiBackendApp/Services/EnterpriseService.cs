using BlurTeknolojiBackendApp.Data;
using BlurTeknolojiBackendApp.DTO;
using BlurTeknolojiBackendApp.Models;
using BlurTeknolojiBackendApp.Services;
using Microsoft.EntityFrameworkCore;

public class EnterpriseService : IEnterpriseService
{
 
    private readonly AppDbContext _context;

    public EnterpriseService(AppDbContext context)
    {
        _context = context;
    }

    // create Enterprise
    public async Task<EnterpriseDto> CreateAsync(CreateEnterpriseDto createEnterpriseDto)
    {
        var entity = new Enterprise
        {
            Id = Guid.NewGuid(),
            Title = createEnterpriseDto.Title,
            Balance = createEnterpriseDto.Balance,
            Verified = true, // Default to true
            Disabled = false, // Default to false
            CreatedAt = DateTimeOffset.UtcNow,
            Phone = createEnterpriseDto.Phone,
            Email = createEnterpriseDto.Email,
            Address = createEnterpriseDto.Address,
            TaxNumber = createEnterpriseDto.TaxNumber,
            TaxAddress = new TaxAddress
            {
                Province = createEnterpriseDto.TaxProvince,
                District = createEnterpriseDto.TaxDistrict
            }
        };
        _context.Enterprises.Add(entity);
        await _context.SaveChangesAsync();
        // db ye başarılı şekilde kaydedildikten sonra dönüt
        return new EnterpriseDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Balance = entity.Balance,
            Verified = entity.Verified,
            Disabled = entity.Disabled,
            CreatedAt = entity.CreatedAt,
            Phone = entity.Phone,
            Email = entity.Email,
            Address = entity.Address,
            TaxNumber = entity.TaxNumber,
            TaxProvince = entity.TaxAddress.Province,
            TaxDistrict = entity.TaxAddress.District
        };

    }

    // delete Enterprise
    public async Task<bool> DeleteAsync(Guid id)
    {
        var enterprice = await _context.Enterprises.FindAsync(id);
        if (enterprice is null)
        {
            return false; // Enterprise not found
        }
        _context.Enterprises.Remove(enterprice);
        await _context.SaveChangesAsync();
        return true;
    }


// get all enterprises
    public async Task<IEnumerable<EnterpriseDto>> GetAllAsync()
    {
        return await _context.Enterprises
    .OrderByDescending(enterprice => enterprice.CreatedAt)
    .Select(enterprice => new EnterpriseDto
    {
        Id = enterprice.Id,
        Title = enterprice.Title,
        Balance = enterprice.Balance,
        Verified = enterprice.Verified,
        Disabled = enterprice.Disabled,
        CreatedAt = enterprice.CreatedAt,
        Phone = enterprice.Phone,
        Email = enterprice.Email,
        Address = enterprice.Address,
        TaxNumber = enterprice.TaxNumber,
        TaxProvince = enterprice.TaxAddress.Province,
        TaxDistrict = enterprice.TaxAddress.District
    })
    .ToListAsync();

    }
    // get by id only 1
    public async Task<EnterpriseDto?> GetByIdAsync(Guid id)
    {
        var enterprice = await _context.Enterprises
        .Include(x => x.TaxAddress)
        .FirstOrDefaultAsync(x => x.Id == id);
        if (enterprice is null)
        {
            return null;
        }
        return new EnterpriseDto
        {
            Id = enterprice.Id,
            Title = enterprice.Title,
            Balance = enterprice.Balance,
            Verified = enterprice.Verified,
            Disabled = enterprice.Disabled,
            CreatedAt = enterprice.CreatedAt,
            Phone = enterprice.Phone,
            Email = enterprice.Email,
            Address = enterprice.Address,
            TaxNumber = enterprice.TaxNumber,
            TaxProvince = enterprice.TaxAddress.Province,
            TaxDistrict = enterprice.TaxAddress.District
        };
    }
    // update Enterprise
    public async Task<UpdateEnterpriseDto> UpdateAsync(UpdateEnterpriseDto updateEnterpriseDto)
    {
        var enterprice = await _context.Enterprises
        .Include(e => e.TaxAddress)
        .FirstOrDefaultAsync(e => e.Id == updateEnterpriseDto.Id);       
    
     if (enterprice is null)
        {
            return null;
        }
        enterprice.Title = updateEnterpriseDto.Title;
        enterprice.Balance = updateEnterpriseDto.Balance;
        enterprice.Verified = updateEnterpriseDto.Verified;
        enterprice.Disabled = updateEnterpriseDto.Disabled;
      //   enterprice.CreatedAt = updateEnterpriseDto.CreatedAt; bunu günceleme yapmayacağız
        enterprice.Phone = updateEnterpriseDto.Phone;
        enterprice.Email = updateEnterpriseDto.Email;
        enterprice.Address = updateEnterpriseDto.Address;
        enterprice.TaxNumber = updateEnterpriseDto.TaxNumber;
        enterprice.TaxAddress.Province = updateEnterpriseDto.TaxProvince;
        enterprice.TaxAddress.District = updateEnterpriseDto.TaxDistrict;

        _context.Enterprises.Update(enterprice);
        await _context.SaveChangesAsync();
        return new UpdateEnterpriseDto
        {
            Id = enterprice.Id,
            Title = enterprice.Title,
            Balance = enterprice.Balance,
            Verified = enterprice.Verified,
            Disabled = enterprice.Disabled,
            Phone = enterprice.Phone,
            Email = enterprice.Email,
            Address = enterprice.Address,
            TaxNumber = enterprice.TaxNumber,
            TaxProvince = enterprice.TaxAddress.Province,
            TaxDistrict = enterprice.TaxAddress.District
        };
    }
}