using softone_task_management_backend.Domains.Common;

namespace softone_task_management_backend.Domains.Entities
{
    public class User : AuditableEntity
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
