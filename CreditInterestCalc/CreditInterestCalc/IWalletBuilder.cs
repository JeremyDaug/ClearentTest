using System;
using System.Collections.Generic;
using System.Text;

namespace CreditInterestCalc
{
    /// <summary>
    /// Wallet Builder Interface
    /// </summary>
    public interface IWalletBuilder
    {
        /// <summary>
        /// Wallet Builder
        /// </summary>
        /// <returns>A new Wallet</returns>
        IWallet Build();
    }
}
