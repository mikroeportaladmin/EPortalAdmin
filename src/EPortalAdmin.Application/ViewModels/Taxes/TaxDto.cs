namespace EPortalAdmin.Application.ViewModels.Taxes
{
    public class TaxDto
    {
        public int? Id { get; set; }
        public string? Code { get; set; }
        public int? Order { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public int Factor { get; set; }
        public bool IsRate { get; set; }
    }
}