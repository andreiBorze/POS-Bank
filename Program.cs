using POS_Bank.Exceptions;
using System;

namespace POS_Bank
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var bank = new Bank();

                var accountId1 = bank.CreateAccount();

                var cardDebit = bank.IssueCard(accountId1, "1234567890123456", DateTime.Now.AddYears(2), 123);
                var cardCumparaturi = bank.IssueCard(accountId1, "1234567890666456", DateTime.Now.AddYears(5), 323);

                bank.Deposit(cardDebit, 100);
                bank.Deposit(cardDebit, 300);

                //var cardEconomii = bank.IssueCard(accountId, "1234567890666488", DateTime.Now.AddYears(4), 998);
                //var cardCumparaturi2 = bank.IssueCard(accountId, "7774567890666488", DateTime.Now.AddYears(5), 798);

                Pos pos = new Pos(bank);
                pos.Pay(cardDebit, 50);

                var accountId2 = bank.CreateAccount();

                var cardDebit2 = bank.IssueCard(accountId2, "1234567890123456", DateTime.Now.AddYears(2), 123);
                var cardCumparaturi2 = bank.IssueCard(accountId2, "1234567890666456", DateTime.Now.AddYears(5), 323);
                //var cardEconomii2 = bank.IssueCard(accountId1, "1234567890666488", DateTime.Now.AddYears(4), 998);

                bank.Deposit(cardDebit2, 44);
                //bank.Deposit(cardEconomii2, 300);

                Pos pos2 = new Pos(bank);
                pos2.Pay(cardCumparaturi2, 50);
            }
            
            catch (CardNotFoundException e)
            {
                Console.WriteLine($"The card with the id: {e.cardId} is not found!");
            }
            catch (AccountNotFoundException e)
            {
                Console.WriteLine($"The account {e.accountId}V was not found.");
            }
            catch (NotEnoghtMoneyInAccountException e)
            {
                Console.WriteLine($"Could not withdraw {e.amount} from the account with ID {e.accountId}. Insufficient funds.");
            }
            catch (ToManyConnectionsOpenException e)
            {
                Console.WriteLine($"To many open connections: {e.nrOpenConnentions}");
            }
            catch (ToManyCardsForAccount e)
            {
                Console.WriteLine($"Two cards have already been issued for the ID account {e.accountId}.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
            finally
            {
                Console.WriteLine("Done. Have a great day!");
            }


            Console.ReadLine();
        }
    }
}
