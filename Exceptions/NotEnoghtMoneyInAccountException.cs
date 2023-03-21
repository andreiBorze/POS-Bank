using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Bank.Exceptions
{
    public class NotEnoghtMoneyInAccountException : Exception
    {
        public Guid accountId { get; private set; }
        public decimal amount { get; private set; }

        public NotEnoghtMoneyInAccountException( Guid account, decimal value)
        {
            accountId = account;
            amount = value;
        }
    }
}
