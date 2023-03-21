using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Bank.Exceptions
{
    public class ToManyCardsForAccount : Exception
    {
        public Guid accountId { get; private set; }

        public ToManyCardsForAccount( Guid account_Id)
        {
            accountId = account_Id;
        }
    }
}
