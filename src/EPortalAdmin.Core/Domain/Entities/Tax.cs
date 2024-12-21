namespace EPortalAdmin.Core.Domain.Entities
{
    public class Tax : BaseEntity
    {
        public string? Code { get; set; }
        public int? Order { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public int Factor { get; set; }
        public bool IsRate { get; set; }
    }
}