using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Domain.Admins.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public string? Description { get; set; } 
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        public List<Menu> Menus { get; } = new();


    }
}
