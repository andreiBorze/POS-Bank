using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Bank
{
    public class Card
    {
        public Guid id_card { get; private set; }
        public string Number { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public int Cvv { get; private set; }
        public bool IsBlocked { get; private set; }

        public Card(string number, DateTime expirationDate, int cvv)
        {
            id_card = Guid.NewGuid();
            Number = number;
            ExpirationDate = expirationDate;
            Cvv = cvv;
            IsBlocked = false;
        }

        public void IntroduCard()
        {
            Console.WriteLine("Cardul este introdus...");
        }

        public Guid GetCardData()
        {
            return id_card;
        }

        public void ExtrageCard()
        {
            Console.WriteLine("Cardul este extras...");
        }


        public void Block()
        {
            IsBlocked = true;
        }

        public void Unblock()
        {
            IsBlocked = false;
        }

        public override string ToString()
        {
            return String.Format("Card Id: {0}, Number: {1}, Expiration date: {2}", id_card, Number, ExpirationDate.ToString("MM/yyyy"));
        }
    }
}
