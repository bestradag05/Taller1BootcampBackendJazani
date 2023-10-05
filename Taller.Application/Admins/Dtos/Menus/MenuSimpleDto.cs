namespace Taller.Application.Admins.Dtos.Menus
{
    public class MenuSimpleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default;

        public int Order { get; set; } = default;

        public int Level { get; set; } = default;
        public bool Visible { get; set; }
    }
}
