using System.ComponentModel.DataAnnotations;

namespace BlurTeknolojiBackendApp.DTO
{
    public class UpdateEnterpriseDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = ("Şirket adı must"))]
        public string? Title { get; set; }
        
        [Required(ErrorMessage = ("Telefon numrası must"))]
        [RegularExpression(@"^90\d{10}$", ErrorMessage = "Telefon numarası geçersiz")]
        public string? Phone {  get; set; }


        [Required(ErrorMessage = ("Email must"))]
        [EmailAddress(ErrorMessage = "Email geçersiz")]
        public string? Email { get; set; }

        [Range(0,double.MaxValue, ErrorMessage = "Sıfırdan büyük olmalı")]

        public decimal Balance { get; set; }

        public bool Verified {  get; set; }


        public string? Address { get; set; }

        [Required(ErrorMessage = ("vergi numrası zorunlu"))]
        [StringLength(10,MinimumLength =10,ErrorMessage =("vergi numarası 10 haneli olmalı"))]
        public string TaxNumber { get; set; }
        
     
        public string? TaxProvince { get; set; }
        
        public string? TaxDistrict { get; set; }

        public bool Disabled { get; set; }

    }
}
