using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Application.Admins.Dtos.Menus
{
    public class menuSaveDto
    {
        public string Name { get; set; } = default;

        public int Order { get; set; } = default;

        public int Level { get; set; } = default;
        public bool Visible { get; set; }
    }
}
