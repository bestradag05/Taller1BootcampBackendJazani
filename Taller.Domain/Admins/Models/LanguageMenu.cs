namespace Taller.Domain.Admins.Models
{
    public class LanguageMenu
    {
        public int LanguageId { get; set; }
        public int MenuId { get; set; }

        public string Name { get; set; } 

        public DateTimeOffset RegistrationDate { get; set; }
        public bool State { get; set; }

        public virtual Language Language { get; set; } 

        public virtual Menu Menu { get; set; } 
    }
}
