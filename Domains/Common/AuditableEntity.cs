namespace softone_task_management_backend.Domains.Common
{
    public class AuditableEntity : BaseEntity
    {
        public DateTimeOffset Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTimeOffset? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }
    }
}
