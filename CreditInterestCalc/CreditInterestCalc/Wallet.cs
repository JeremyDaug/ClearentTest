using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CreditInterestCalc
{
    public class Wallet : IWallet
    {
        private ICreditCardBuilder cardBuilder;

        /// <summary>
        /// Wallet Constructor.
        /// </summary>
        /// <param name="cardBuilder">The Credit Card Builder.</param>
        public Wallet(ICreditCardBuilder cardBuilder)
        {
            this.cardBuilder = cardBuilder;
            Cards = new List<ICreditCard>();
        }

        /// <summary>
        /// The Current Balance of the Wallet.
        /// </summary>
        public double Balance
        {
            get
            {
                return Cards.Sum(x => x.Balance);
            }
        }

        /// <summary>
        /// The Available cards in the Wallet.
        /// </summary>
        public IList<ICreditCard> Cards { get; }

        /// <summary>
        /// Calculates the interest that would generate over months.
        /// </summary>
        /// <param name="months">How many months.</param>
        /// <returns>The interest accrued over that time.</returns>
        public double CalculateInterest(int months)
        {
            return Cards.Sum(x => x.CalculateInterest(months));
        }

        /// <summary>
        /// Apply interest to the wallet's balance.
        /// </summary>
        /// <param name="months">How many months of interest to accrue.</param>
        public void ApplyInterest(int months)
        {
            foreach(var card in Cards)
            {
                card.ApplyInterest(months);
            }
        }

        /// <summary>
        /// Adds a card to the wallet.
        /// </summary>
        /// <param name="cardName">The name of the card.</param>
        /// <param name="cardInterest">The Interest of the card</param>
        /// <param name="cardBalance">The existing balance on it</param>
        public void AddCard(string cardName, double cardInterest, double cardBalance)
        {
            Cards.Add(cardBuilder.BuildCreditCard(cardName, cardInterest, cardBalance));
        }
    }
}
