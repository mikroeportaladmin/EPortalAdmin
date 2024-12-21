using System.ComponentModel.DataAnnotations.Schema;

namespace EPortalAdmin.Core.Domain.Entities
{
    public class ServiceLog : BaseEntity
    {
        public int? UserId { get; set; }
        public Guid CorrelationId { get; set; }
        public int EndpointId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string QueryString { get; set; }
        public string HttpMethod { get; set; }
        public long ResponseTimeInMilliseconds { get; set; }
        public string IpAddress { get; set; }
        public string BrowserName { get; set; }
        public int ResponseHttpStatusCode { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
        public string HttpHeaders { get; set; }
        public string RouteValuesJson { get; set; }
        public string Message { get; set; }


        [NotMapped]
        public override DateTime CreatedDate { get => base.CreatedDate; set => base.CreatedDate = value; }
        [NotMapped]
        public override int? CreatedBy { get => base.CreatedBy; set => base.CreatedBy = value; }
        [NotMapped]
        public override DateTime? UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
        [NotMapped]
        public override int? UpdatedBy { get => base.UpdatedBy; set => base.UpdatedBy = value; }
        [NotMapped]
        public override bool IsDeleted { get => base.IsDeleted; set => base.IsDeleted = value; }
        [NotMapped]
        public override int? DeletedBy { get => base.DeletedBy; set => base.DeletedBy = value; }
        [NotMapped]
        public override DateTime? DeletedDate { get => base.DeletedDate; set => base.DeletedDate = value; }
    }
}
