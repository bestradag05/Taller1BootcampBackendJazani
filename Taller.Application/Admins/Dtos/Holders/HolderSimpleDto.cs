using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Application.Admins.Dtos.Holders
{
    public class HolderSimpleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string MaidenName { get; set; }

        public string DocumentNumber { get; set; }
    }
}
