using Taller.Application.Admins.Dtos.Languages;
using Taller.Application.Admins.Dtos.Permissions;

namespace Taller.Application.Admins.Dtos.Menus
{
    public class MenuDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default;

        public int Order { get; set; } = default;

        public int Level { get; set; } = default;
        public bool Visible { get; set; }

        public List<LanguageSimpleDto> Languages { get; set; }

        public List<PermissionSimpleDto> Permissions { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
