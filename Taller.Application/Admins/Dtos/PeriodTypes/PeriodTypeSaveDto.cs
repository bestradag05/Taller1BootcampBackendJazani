using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Application.Admins.Dtos.PeriodTypes
{
    public class PeriodTypeSaveDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public int Time { get; set; }

    }
}
