using System.Collections.Generic;

namespace CreditInterestCalc
{
    /// <summary>
    /// User Class Interface.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// The current, summated Balance of the user.
        /// </summary>
        double Balance { get; }

        /// <summary>
        /// The name of the user.
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        /// The user's wallets.
        /// </summary>
        IList<IWallet> Wallets { get; set; }

        /// <summary>
        /// Adds a card to one of the user's wallets.
        /// </summary>
        /// <param name="wallet">Which wallet to add the card to.</param>
        /// <param name="cardName">The name of the card.</param>
        /// <param name="cardInterest">The card's interest rate.</param>
        /// <param name="cardBalance">The card's starting balance.</param>
        void AddCard(int wallet, string cardName, double cardInterest, double cardBalance);

        /// <summary>
        /// Adds a new wallet to the user.
        /// </summary>
        void AddWallet();

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