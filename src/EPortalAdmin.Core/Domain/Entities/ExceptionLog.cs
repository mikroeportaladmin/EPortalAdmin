using System.ComponentModel.DataAnnotations.Schema;

namespace EPortalAdmin.Core.Domain.Entities
{
    public class ExceptionLog : BaseEntity
    {
        public Guid CorrelationId { get; set; }
        public int HttpStatusCode { get; set; }
        public string Title { get; set; }
        public string ExceptionMessage { get; set; }
        public string InnerExceptionMessage { get; set; }
        public string StackTrace { get; set; }
        public string ValidationErrors { get; set; }
        public string Instance { get; set; }
        public string Type { get; set; }
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
