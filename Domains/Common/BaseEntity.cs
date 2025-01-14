namespace softone_task_management_backend.Domains.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
