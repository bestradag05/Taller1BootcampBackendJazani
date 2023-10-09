using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Application.Admins.Dtos.MiningConsessions
{
    public class MiningConsessionSaveDto
    {

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


    }
}
