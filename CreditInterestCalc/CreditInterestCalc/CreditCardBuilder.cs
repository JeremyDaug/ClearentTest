using System;
using System.Collections.Generic;
using System.Text;

namespace CreditInterestCalc
{
    /// <summary>
    /// Credit Card Builder Class.
    /// </summary>
    public class CreditCardBuilder : ICreditCardBuilder
    {
        /// <summary>
        /// Builder Function, not separated into builder Class for simplicity.
        /// </summary>
        /// <param name="cardName">Name of the Card</param>
        /// <param name="interestRate"></param>
        /// <param name="balance">The starting balance on the card.</param>
        /// <returns>The New Card</returns>
        public ICreditCard BuildCreditCard(string cardName, double interestRate, double balance)
        {
            return new CreditCard
            {
                CardName = cardName,
                Balance = balance,
                InterestRate = interestRate
            };
        }
    }
}
