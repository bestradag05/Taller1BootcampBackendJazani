namespace Taller.Domain.Admins.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Slug { get; set; }

        public DateTimeOffset RegistrationDate { get; set; }
        public bool State { get; set; }

        public List<Menu> Menus { get; } = new();
    }
}
