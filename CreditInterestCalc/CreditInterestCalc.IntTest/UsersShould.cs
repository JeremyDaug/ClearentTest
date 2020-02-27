using CreditInterestCalc;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class UsersShould
    {
        private Users sut;
        private IUserBuilder userBuilder;
        private IWalletBuilder walletBuilder;
        private ICreditCardBuilder cardBuilder;

        private const string user1 = "Alice";
        private const string user2 = "Bob";

        private const string Visa = "Visa";
        private const double VisaInterest = 0.10;

        private const string MC = "MasterCard";
        private const double MCInterest = 0.05;

        private const string Discover = "Discover";
        private const double DiscoverInterest = 0.01;

        private const int months = 1;

        [SetUp]
        public void Setup()
        {
            cardBuilder = new CreditCardBuilder();
            walletBuilder = new WalletBuilder(cardBuilder);
            userBuilder = new UserBuilder(walletBuilder);
            sut = new Users(userBuilder);
        }

        /// <summary>
        /// 1 person, 1 wallet, 3 cards (1 visa, MC, Discover) with 100$ each. Calculate interest per card.
        /// </summary>
        [Test]
        public void Test1()
        {
            sut.AddPerson(user1);
            sut.AddWalletToPerson(user1);
            sut.AddCardToWallet(user1, 0, Visa, VisaInterest, 100);
            sut.AddCardToWallet(user1, 0, MC, MCInterest, 100);
            sut.AddCardToWallet(user1, 0, Discover, DiscoverInterest, 100);

            // Check that the interest calculated for 1 month is correct.
            var Alice = sut.GetPerson(user1);
            Assert.That(Alice.CalculateInterest(months), Is.EqualTo(16));

            // Do it for each card.
            Assert.That(Alice.Wallets[0].Cards.Single(x => x.CardName == Visa).CalculateInterest(months), Is.EqualTo(10));
            Assert.That(Alice.Wallets[0].Cards.Single(x => x.CardName == MC).CalculateInterest(months), Is.EqualTo(5));
            Assert.That(Alice.Wallets[0].Cards.Single(x => x.CardName == Discover).CalculateInterest(months), Is.EqualTo(1));
        }

        /// <summary>
        /// 1 person 2 wallets, W1 has Visa and Discover, W2 has MC, all cards have 100$ each. Calculate total and per wallet.
        /// </summary>
        [Test]
        public void Test2()
        {
            sut.AddPerson(user1);
            sut.AddWalletToPerson(user1);
            sut.AddWalletToPerson(user1);
            sut.AddCardToWallet(user1, 0, Visa, VisaInterest, 100);
            sut.AddCardToWallet(user1, 1, MC, MCInterest, 100);
            sut.AddCardToWallet(user1, 0, Discover, DiscoverInterest, 100);

            // Check total interest for Alice.
            var Alice = sut.GetPerson(user1);
            Assert.That(Alice.CalculateInterest(months), Is.EqualTo(16));

            // Check interest for each wallet.
            var wallet1 = Alice.Wallets[0];
            var wallet2 = Alice.Wallets[1];

            Assert.That(wallet1.CalculateInterest(months), Is.EqualTo(11));
            Assert.That(wallet2.CalculateInterest(months), Is.EqualTo(5));
        }

        /// <summary>
        /// 2 people, 1 wallet each, Person 1 has wallet with MC and Visa, Person 2 has wallet with Visa and MC.
        /// Check interest for each person and interest per wallet.
        /// </summary>
        [Test]
        public void Test3()
        {
            // 2 people
            sut.AddPerson(user1);
            sut.AddPerson(user2);

            // 1 wallet each
            sut.AddWalletToPerson(user1);
            sut.AddWalletToPerson(user2);

            // person 1 has MC and Visa in wallet.
            sut.AddCardToWallet(user1, 0, MC, MCInterest, 100);
            sut.AddCardToWallet(user1, 0, Visa, VisaInterest, 100);

            // person 2 has Visa and MC in wallet.
            sut.AddCardToWallet(user2, 0, Visa, VisaInterest, 100);
            sut.AddCardToWallet(user2, 0, MC, MCInterest, 100);

            // Check interest across each person.
            Assert.That(sut.GetPerson(user1).CalculateInterest(months), Is.EqualTo(15));
            Assert.That(sut.GetPerson(user2).CalculateInterest(months), Is.EqualTo(15));

            // check interest across each wallet.
            Assert.That(sut.GetPerson(user1).Wallets[0].CalculateInterest(months), Is.EqualTo(15));
            Assert.That(sut.GetPerson(user2).Wallets[0].CalculateInterest(months), Is.EqualTo(15));
        }
    }
}