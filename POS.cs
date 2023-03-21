using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Bank
{
    public class Pos
    {
        private readonly Bank _bank;
        private int _connectionAttempts;

        public Pos(Bank bank)
        {
            _bank = bank;
        }

        public void Pay(Card card, decimal amount)
        {
            card.IntroduCard();
            Connect();
            _bank.Pay(card, amount);
            Disconnect();
            card.ExtrageCard();
        }

        private void Connect()
        {
            const int maxAttempts = 2;

            while (_connectionAttempts < maxAttempts)
            {
                try
                {
                    _bank.Connect();
                    Console.WriteLine("Connected to bank.");
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to connect to bank: {ex.Message}");
                    _connectionAttempts++;
                }
            }

            throw new Exception("Could not connect to bank.");
        }

        private void Disconnect()
        {
            _bank.Disconnect();
            Console.WriteLine("Disconnected from bank.");
        }
    }
}
