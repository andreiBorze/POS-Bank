using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Bank.Exceptions
{
    public class AccountNotFoundException : Exception
    {
        public Guid accountId { get; private set; }

        public AccountNotFoundException(Guid account)
        {
            accountId = account;
        }
    }
}
