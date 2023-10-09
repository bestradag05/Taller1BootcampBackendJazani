using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Domain.Admins.Models
{
    public class MiningConcession
    {
        public int Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }

        public string? Description { get; set; }
        public int MineralTypeId { get; set; }

        public int OriginId { get; set; }

        public int TypeId { get; set; }

        public int SituationId { get; set; }

        public int MiningunitId { get; set; }

        public int ConditionId { get; set; }

        public int StatemanagementId { get; set; }

        public bool Issincronized { get; set; }

        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        public ICollection<Investment> Investments { get; set; } //Realizando la realacion inversa de Invesment a MininConcession
    }
}
