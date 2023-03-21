using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Bank.Exceptions
{



    public class ToManyConnectionsOpenException : Exception
    {
        public int nrOpenConnentions { get; private set; }

        public ToManyConnectionsOpenException(int nrConnentions)
        {
            nrOpenConnentions = nrConnentions;
        }
    }
}
