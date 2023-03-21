using POS_Bank.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Bank
{
    public class Account
    {
        public Guid id_account { get; private set; }
        public decimal Sold { get; set; }
        public int IssuedCards { get; set; }
        public Account(decimal initialSold)
        {
            id_account = Guid.NewGuid();
            Sold = initialSold;
            IssuedCards = 0;
        }

        public void Deposit(decimal value)
        {
            Sold += value;
        }

        public void Withdrawal(decimal value)
        {
            if(Sold >= value)
            {
                Sold -= value;
                Console.WriteLine($"Successfully withdrew {value} from the account with ID {id_account}");
            }
            else
            {
                throw new NotEnoghtMoneyInAccountException(id_account,value);
            }
        }

        public void IssueCard()
        {
            IssuedCards++;
        }
    }
}
