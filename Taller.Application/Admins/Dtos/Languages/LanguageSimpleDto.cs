﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Application.Admins.Dtos.Languages
{
    public class LanguageSimpleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public string Description { get; set; }
    }
}
