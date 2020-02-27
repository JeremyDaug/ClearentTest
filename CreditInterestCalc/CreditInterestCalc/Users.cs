using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CreditInterestCalc
{

    /// <summary>
    /// Container for multiple users.
    /// </summary>
    public class Users
    {
        private IUserBuilder userBuilder;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="userBuilder">The User Builder Helper class.</param>
        public Users(IUserBuilder userBuilder)
        {
            this.userBuilder = userBuilder;
            People = new List<IUser>();
        }

        /// <summary>
        /// All people that currently exist in the system.
        /// </summary>
        public IList<IUser> People { get; }

        /// <summary>
        /// Adds a person to the list
        /// </summary>
        /// <param name="name">The new User's name.</param>
        public void AddPerson(string name)
        {
            People.Add(userBuilder.BuildUser(name));
        }

        /// <summary>
        /// Adds a wallet to a user.
        /// </summary>
        /// <param name="person"></param>
        public void AddWalletToPerson(string person)
        {
            var user = People.Single(x => x.UserName == person);
            user.AddWallet();
        }

        /// <summary>
        /// Adds a card to a persons wallet.
        /// </summary>
        /// <param name="person">The person to add the card to.</param>
        /// <param name="wallet">That person's wallet to add the card to.</param>
        /// <param name="cardName">The name of the card.</param>
        /// <param name="interestRate">The interest rate of the card.</param>
        /// <param name="cardBalance">The current balance of the card.</param>
        public void AddCardToWallet(string person,
                                    int wallet,
                                    string cardName,
                                    double interestRate,
                                    double cardBalance)
        {
            var user = People.Single(x => x.UserName == person);
            user.AddCard(wallet, cardName, interestRate, cardBalance);
        }

        /// <summary>
        /// A helper to get a designated person.
        /// </summary>
        /// <param name="user">The user to retrieve.</param>
        /// <returns>The user requested.</returns>
        public IUser GetPerson(string user)
        {
            return People.Single(x => x.UserName == user);
        }
    }
}
