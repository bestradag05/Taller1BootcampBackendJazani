﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Application.Cores.Exceptions
{
    public class NotFoundCoreException : Exception
    {
        public NotFoundCoreException(string message) : base(message) { 
        
        
        }
    }
}
