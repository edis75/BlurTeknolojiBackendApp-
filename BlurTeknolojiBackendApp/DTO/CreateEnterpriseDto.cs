using System.ComponentModel.DataAnnotations;

namespace BlurTeknolojiBackendApp.DTO
{
    public class CreateEnterpriseDto
    {
        [Required(ErrorMessage ="Şirket adı must")]
        public required string Title { get; set; }

        [Required(ErrorMessage = ("Telefon numrası must"))]
        [RegularExpression(@"^90\d{10}$", ErrorMessage = "Telefon numarası geçersiz")]
        public required string Phone { get; set; }

        [Required(ErrorMessage = ("Email must"))]
        [EmailAddress(ErrorMessage = "Email geçersiz")]
        public required string Email { get; set; }
         
         [Range(0,double.MaxValue, ErrorMessage = "Sıfırdan büyük olmalı")]
        public required decimal Balance { get; set; }
        
        public string Address { get; set; }

        [Required(ErrorMessage = ("vergi numrası zorunlu"))]
        [MaxLength(10, ErrorMessage = ("vergi numarası 10  haneli olabilir max"))]
        [MinLength(10, ErrorMessage = ("vergi numarası 10 haneli olabilir min"))]
        public string  TaxNumber { get; set; }

     
        public required string TaxProvince { get; set; }

        public string TaxDistrict { get; set; }
    }
}
