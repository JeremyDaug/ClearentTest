using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditInterestCalc.Test
{
    [TestFixture]
    public class UserBuilderShould
    {
        private UserBuilder sutBuilder;

        private Mock<IWalletBuilder> walletBuilderMock;

        [SetUp]
        public void Setup()
        {
            walletBuilderMock = new Mock<IWalletBuilder>();

            sutBuilder = new UserBuilder(walletBuilderMock.Object);
        }

        [Test]
        [TestCase("name")]
        public void ReturnNewUser(string userName)
        {
            var result = sutBuilder.BuildUser(userName);

            Assert.That(result, Is.AssignableTo<IUser>());
            Assert.That(result.UserName, Is.EqualTo(userName));
        }
    }
}
