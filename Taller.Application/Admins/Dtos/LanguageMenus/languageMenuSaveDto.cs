using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Application.Admins.Dtos.LanguageMenus
{
    public class languageMenuSaveDto
    {
        public int languageId { get; set; }
        public int MenuId { get; set; }

        public string Name { get; set; }

    }
}
