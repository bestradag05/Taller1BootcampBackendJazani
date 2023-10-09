using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Domain.Admins.Models
{
    public class Holder
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string MaidenName { get; set; }

        public string DocumentNumber { get; set; }

        public int HolderregimeId { get; set; }

        public int HoldergroupId { get; set; }

        public int RegistryOfficeId { get; set; }

        public int IdentificationDocumentId { get; set; }

        public int HoldertypeId { get; set; }

        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        public virtual ICollection<Investment>? Investments { get; set; } //Realizando la realacion inversa de Invesment a Holder

    }
}
