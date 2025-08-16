namespace BlurTeknolojiBackendApp.DTO;

public class EnterpriseDto
{
    public Guid Id { get; set; }

    public string Title { get; set; }
    public decimal Balance { get; set; }
    public bool Verified { get; set; }
    public bool Disabled { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    // detay için 

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string TaxNumber { get; set; }

    public string? TaxProvince { get; set; }

    public string? TaxDistrict { get; set; }
     
     

}