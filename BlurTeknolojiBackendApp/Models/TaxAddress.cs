namespace BlurTeknolojiBackendApp.Models
{
    public class TaxAddress
    {
        public Guid Id { get; set; }
        public required string Province { get; set; }= null!;
        public string District { get; set; }= null!;
    }
}
