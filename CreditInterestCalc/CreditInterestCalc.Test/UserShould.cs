using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditInterestCalc.Test
{
    [TestFixture]
    public class UserShould
    {
        private User sut;

        private Mock<IWalletBuilder> walletBuilderMock;
        private Mock<IWallet> wallet1Mock;
        private Mock<IWallet> wallet2Mock;

        [SetUp]
        public void Setup()
        {
            walletBuilderMock = new Mock<IWalletBuilder>();
            wallet1Mock = new Mock<IWallet>();
            wallet2Mock = new Mock<IWallet>();

            walletBuilderMock.Setup(x => x.Build()).Returns(wallet1Mock.Object);

            sut = new User(walletBuilderMock.Object);
        }

        [Test]
        [TestCase(1)]
        public void ReturnTheBalanceOfTheWallets(double balance)
        {
            wallet1Mock.Setup(x => x.Balance).Returns(balance);
            sut.Wallets.Add(wallet1Mock.Object);

            Assert.That(sut.Balance, Is.EqualTo(balance));

            wallet1Mock.Verify(x => x.Balance, Times.Once);
        }

        [Test]
        [TestCase(1, 1)]
        public void ReturnTheSumOfMultipleWallets(double val1, double val2)
        {
            wallet1Mock.Setup(x => x.Balance).Returns(val1);
            wallet2Mock.Setup(x => x.Balance).Returns(val2);

            sut.Wallets.Add(wallet1Mock.Object);
            sut.Wallets.Add(wallet2Mock.Object);

            Assert.That(sut.Balance, Is.EqualTo(val1 + val2));
        }

        [Test]
        [TestCase("Name", 1, 1)]
        public void CallAddCardToWalletSelected(string name, double interest, double balance)
        {
            sut.Wallets.Add(wallet1Mock.Object);
            sut.Wallets.Add(wallet2Mock.Object);

            sut.AddCard(0, name, interest, balance);

            wallet1Mock.Verify(x => x.AddCard(name, interest, balance), Times.Once);
            wallet2Mock.Verify(x => x.AddCard(name, interest, balance), Times.Never);
        }

        [Test]
        public void CallBuildWalletAndAddToWallets()
        {
            sut.AddWallet();

            walletBuilderMock.Verify(x => x.Build(), Times.Once);

            Assert.That(sut.Wallets.Contains(wallet1Mock.Object));
        }

        [Test]
        [TestCase(1)]
        public void ApplyInterestToWallets(int months)
        {
            sut.Wallets.Add(wallet1Mock.Object);
            sut.Wallets.Add(wallet2Mock.Object);

            sut.ApplyInterest(months);

            wallet1Mock.Verify(x => x.ApplyInterest(months));
            wallet2Mock.Verify(x => x.ApplyInterest(months));
        }

        [Test]
        [TestCase(1, 1, 1)]
        public void CalculateInterestOnWallets(int months, double val1, double val2)
        {
            wallet1Mock.Setup(x => x.CalculateInterest(months)).Returns(val1);
            wallet2Mock.Setup(x => x.CalculateInterest(months)).Returns(val2);

            sut.Wallets.Add(wallet1Mock.Object);
            sut.Wallets.Add(wallet2Mock.Object);

            Assert.That(sut.CalculateInterest(months), Is.EqualTo(val1 + val2));

            wallet1Mock.Verify(x => x.CalculateInterest(months), Times.Once);
            wallet2Mock.Verify(x => x.CalculateInterest(months), Times.Once);
        }
    }
}
