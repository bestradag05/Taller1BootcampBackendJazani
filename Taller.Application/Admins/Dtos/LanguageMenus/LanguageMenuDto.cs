using Taller.Application.Admins.Dtos.Languages;
using Taller.Application.Admins.Dtos.Menus;

namespace Taller.Application.Admins.Dtos.LanguageMenus
{
    public class LanguageMenuDto
    {
        public int languageId { get; set; }
        public int MenuId { get; set; }

        public string Name { get; set; }

        public LanguageDto Language { get; set; }

        public MenuSimpleDto Menu { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
