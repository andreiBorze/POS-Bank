using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Bank.Exceptions
{
    public class CardNotFoundException: Exception
    {
        public Guid cardId { get; private set; }

        public CardNotFoundException(Guid card)
        {
            cardId = card;
        }
    }
}
