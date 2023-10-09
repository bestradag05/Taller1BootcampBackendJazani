﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Application.Admins.Dtos.Documents
{
    public class DocumentSaveDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public int ExternalId { get; set; }

        public bool IsFile { get; set; }

    }
}
