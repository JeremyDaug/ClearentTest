using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditInterestCalc.Test
{
    [TestFixture]
    public class WalletBuilderShould
    {
        Mock<ICreditCardBuilder> cardBuilderMock;

        private WalletBuilder sutBuilder;

        [SetUp]
        public void Setup()
        {
            cardBuilderMock = new Mock<ICreditCardBuilder>();

            sutBuilder = new WalletBuilder(cardBuilderMock.Object);
        }

        [Test]
        public void ReturnNewIWallet()
        {
            var result = sutBuilder.Build();
            Assert.That(result, Is.AssignableTo<IWallet>());
        }
    }
}
