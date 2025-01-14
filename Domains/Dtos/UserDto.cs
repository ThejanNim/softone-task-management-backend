namespace softone_task_management_backend.Domains.Dtos
{
    public class UserDto
    {
        public Guid? Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
