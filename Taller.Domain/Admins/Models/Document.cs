using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Domain.Admins.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string? Name { get; set; } 

        public string? Description { get; set; }

        public int ExternalId { get; set; }

        public bool IsFile { get; set; }

        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        public virtual ICollection<Investment>? Investments { get; set; } //Realizando la realacion inversa de Invesment a Document


    }
}
