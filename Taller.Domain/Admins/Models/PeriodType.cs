using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Domain.Admins.Models
{
    public class PeriodType
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Time { get; set; }

        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        public ICollection<Investment> Investments { get; set; } //Realizando la realacion inversa de Invesment a PeriodType
    }
}
