using System;
using System.Collections.Generic;
using System.Text;

namespace CreditInterestCalc
{
    /// <summary>
    /// Wallet Interface
    /// </summary>
    public interface IWallet
    {
        /// <summary>
        /// The Balance across all the cards.
        /// </summary>
        double Balance { get; }

        /// <summary>
        /// Credit Cards in the wallet.
        /// </summary>
        IList<ICreditCard> Cards { get; }

        /// <summary>
        /// Adds card to Wallet
        /// </summary>
        /// <param name="cardName">The Name of the Card</param>
        /// <param name="cardInterest">The interest rate of the card</param>
        /// <param name="cardBalance">The Existing balance on the card</param>
        void AddCard(string cardName, double cardInterest, double cardBalance);

        /// <summary>
        /// Calculates interest over so many months.
        /// </summary>
        /// <param name="months">The number of months.</param>
        /// <returns>The interest accrued.</returns>
        double CalculateInterest(int months);

        /// <summary>
        /// Adds a number of months worth of interest to the balance.
        /// </summary>
        /// <param name="months">The number of months being used.</param>
        void ApplyInterest(int months);
    }
}
