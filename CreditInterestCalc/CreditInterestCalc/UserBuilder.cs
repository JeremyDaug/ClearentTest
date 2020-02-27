using System;
using System.Collections.Generic;
using System.Text;

namespace CreditInterestCalc
{
    public class UserBuilder : IUserBuilder
    {
        private IWalletBuilder walletBuilder;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="walletBuilder">Wallet Builder for Users.</param>
        public UserBuilder(IWalletBuilder walletBuilder)
        {
            this.walletBuilder = walletBuilder;
        }

        /// <summary>
        /// Builds user
        /// </summary>
        /// <param name="name">Name of the new user.</param>
        /// <returns>The new user.</returns>
        public IUser BuildUser(string name)
        {
            var user = new User(walletBuilder);

            user.UserName = name;

            return user;
        }
    }
}
