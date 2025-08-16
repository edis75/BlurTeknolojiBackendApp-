using System.ComponentModel.DataAnnotations;

namespace BlurTeknolojiBackendApp.Models
{
    public class Enterprise
    {
        public  Guid Id { get; set; }

        public required string Title { get; set; }

        public required string Phone { get; set; }

        public required string Email { get; set; }

        [MaxLength(12)]
        public required decimal  Balance { get; set; }// şirket bakiyesi 

        public bool Verified {  get; set; }=true; // var sayılan olarak true

        public string Address { get; set; }

        [MaxLength (10)]
        public string TaxNumber { get; set; }

        public TaxAddress TaxAddress { get; set; } = null!;

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        public bool Disabled { get; set; }
    }
}
