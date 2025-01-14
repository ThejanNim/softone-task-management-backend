using softone_task_management_backend.Domains.Common;

namespace softone_task_management_backend.Domains.Entities
{
    public class Tasks : AuditableEntity
    {
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public bool? IsChecked { get; set; }
    }
}
