using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Domain.Admins.Models
{
    public class LanguageMenu
    {
        public int languageId { get; set; }
        public int MenuId { get; set; }

        public string Name { get; set; } 

        public DateTimeOffset RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}
