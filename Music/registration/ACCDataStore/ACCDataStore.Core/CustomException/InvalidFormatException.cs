﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCDataStore.Core.CustomException
{
    public class InvalidFormatException : Exception
    {
        public InvalidFormatException()
            : base()
        { }

        public InvalidFormatException(string message)
            : base(message)
        { }
    }
}
