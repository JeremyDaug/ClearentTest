using System;
using System.Collections.Generic;
using System.Text;

namespace CreditInterestCalc
{
    public class WalletBuilder : IWalletBuilder
    {
        private ICreditCardBuilder cardBuilder;

        public WalletBuilder(ICreditCardBuilder cardBuilder)
        {
            this.cardBuilder = cardBuilder;
        }

        public IWallet Build()
        {
            return new Wallet(cardBuilder);
        }
    }
}
