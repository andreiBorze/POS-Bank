using POS_Bank.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Bank
{
    public class Bank
    {
        private Dictionary<Guid, Account> accounts;
        private Dictionary<Guid, Guid> cardAccounts;
        private int activeConnections;

        public Bank()
        {
            accounts = new Dictionary<Guid, Account>();
            cardAccounts = new Dictionary<Guid, Guid>();
            activeConnections = 0;
        }

        public Guid CreateAccount()
        {
            Account account = new Account(0);
            accounts.Add(account.id_account, account);
            return account.id_account;
        }

        public Card IssueCard(Guid accountId, string number, DateTime ExpirationDate, int cvv)
        {
            if (!accounts.ContainsKey(accountId))
            {
                throw new AccountNotFoundException(accountId);
            }

            if (accounts.ContainsKey(accountId))
            {
                var count = 0;
                if(cardAccounts.ContainsValue(accountId))
                {           
                    foreach (var pair in cardAccounts)
                    {
                        if (pair.Value == accountId)
                        {
                            count++;
                        }
                    }

                    if (count >= 2)
                    {
                        throw new ToManyCardsForAccount(accountId);
                    }
                }
            }

            Card card = new Card(number,ExpirationDate, cvv);
            cardAccounts.Add(card.id_card, accountId);

            return card;
        }

        public void Pay(Card card, decimal amount)
        {
            if (!cardAccounts.ContainsKey(card.id_card))
            {
                throw new CardNotFoundException(card.id_card);
            }

            var accountId = cardAccounts[card.id_card];

            if (!accounts.ContainsKey(accountId))
            {
                throw new AccountNotFoundException(accountId);
            }

            var account = accounts[accountId];

            if (account.Sold >= amount)
            {
                account.Withdrawal(amount);
                Console.WriteLine($"S-a platit {amount} RON cu cardul cu ID-ul {card.id_card}. Noul sold este {account.Sold} RON.");
            }
            else
            {
                throw new NotEnoghtMoneyInAccountException(accountId, amount); 
            }
        }

        public void Deposit(Card card, decimal amount)
        {
            var accountId = cardAccounts[card.GetCardData()];
            var account = accounts[accountId];
            account.Deposit(amount);
        }

        public void Connect()
        {
            if (activeConnections >= 3)
            {
                throw new ToManyConnectionsOpenException(activeConnections);
            }

            activeConnections++;
            Console.WriteLine("Connected");
        }

        public void Disconnect()
        {
            activeConnections--;
            Console.WriteLine("Disconnected");
        }
    }
}
