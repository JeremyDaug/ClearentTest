using System;
using System.Collections.Generic;
using System.Linq;

namespace CreditInterestCalc
{
    /// <summary>
    /// User Class
    /// </summary>
    public class User : IUser
    {
        private IWalletBuilder walletBuilder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="walletBuilder">The wallet builder helper.</param>
        public User(IWalletBuilder walletBuilder)
        {
            this.walletBuilder = walletBuilder;
            Wallets = new List<IWallet>();
        }

        /// <summary>
        /// The name of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The user's wallets.
        /// </summary>
        public IList<IWallet> Wallets { get; set; }
        
        /// <summary>
        /// The current, summated Balance of the user.
        /// </summary>
        public double Balance
        {
            get
            {
                return Wallets.Sum(x => x.Balance);
            }
        }

        /// <summary>
        /// Adds a card to one of the user's wallets.
        /// </summary>
        /// <param name="wallet">Which wallet to add the card to.</param>
        /// <param name="cardName">The name of the card.</param>
        /// <param name="cardInterest">The card's interest rate.</param>
        /// <param name="cardBalance">The card's starting balance.</param>
        public void AddCard(int wallet, string cardName, double cardInterest, double cardBalance)
        {
            Wallets[wallet].AddCard(cardName, cardInterest, cardBalance);
        }

        /// <summary>
        /// Adds a new wallet to the user.
        /// </summary>
        public void AddWallet()
        {
            Wallets.Add(walletBuilder.Build());
        }

        /// <summary>
        /// Adds a number of months worth of interest to the balance.
        /// </summary>
        /// <param name="months">The number of months being used.</param>
        public void ApplyInterest(int months)
        {
            foreach(var wallet in Wallets)
            {
                wallet.ApplyInterest(months);
            }
        }

        /// <summary>
        /// Calculates interest over so many months.
        /// </summary>
        /// <param name="months">The number of months.</param>
        /// <returns>The interest accrued.</returns>
        public double CalculateInterest(int months)
        {
            return Wallets.Sum(x => x.CalculateInterest(months));
        }
    }
}
