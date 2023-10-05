using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Domain.Admins.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; } = default;

        public int Order { get; set; } = default;

        public int Level { get; set; } = default;
        public bool Visible { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }
        public bool State { get; set; }

        public List<Language> Languages { get; } = new();

        public List<Permission> Permissions { get; } = new();


    }
}
