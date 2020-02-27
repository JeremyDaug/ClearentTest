using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace CreditInterestCalc.Test
{
    [TestFixture]
    public class WalletShould
    {
        private Wallet sut;

        private Mock<ICreditCardBuilder> cardBuilderMock;
        private Mock<ICreditCard> cardMock;

        [SetUp]
        public void Setup()
        {
            cardMock = new Mock<ICreditCard>();

            cardBuilderMock = new Mock<ICreditCardBuilder>();
            cardBuilderMock.Setup(x => x.BuildCreditCard(It.IsAny<string>(),
                It.IsAny<double>(), It.IsAny<double>())).Returns(cardMock.Object);

            sut = new Wallet(cardBuilderMock.Object);
        }

        [Test]
        [TestCase("name", 0, 100)]
        public void AddCardToWallet(string name, double interest, double balance)
        {
            sut.AddCard(name, interest, balance);

            cardBuilderMock
                .Verify(x => x.BuildCreditCard(name, interest, balance), Times.Once);

            Assert.That(sut.Cards.Contains(cardMock.Object));
        }

        [Test]
        [TestCase(100)]
        public void ReturnCorrectBalance(double balance)
        {
            cardMock.Setup(x => x.Balance).Returns(balance);

            sut.AddCard("name", 0, balance);

            var result = sut.Balance;

            Assert.That(result, Is.EqualTo(balance));
            cardMock.Verify(x => x.Balance, Times.Once);
        }
        
        [Test]
        [TestCase(1, 1)]
        public void SumAllCardsWhenBalanceCalled(double val1, double val2)
        {
            cardMock.Setup(x => x.Balance).Returns(val1);
            var cardMock2 = new Mock<ICreditCard>();
            cardMock2.Setup(x => x.Balance).Returns(val2);

            sut.Cards.Add(cardMock.Object);
            sut.Cards.Add(cardMock2.Object);

            Assert.That(sut.Balance, Is.EqualTo(val1 + val2));
        }

        [Test]
        [TestCase(1)]
        public void CallApplyInterestOnACard(int months)
        {
            sut.Cards.Add(cardMock.Object);

            sut.ApplyInterest(months);

            cardMock.Verify(x => x.ApplyInterest(months), Times.Once);
        }

        [Test]
        [TestCase(1)]
        public void CallCalculateInterestOnACard(int months)
        {
            var testInterest = 100;
            cardMock.Setup(x => x.CalculateInterest(months)).Returns(testInterest);
            sut.Cards.Add(cardMock.Object);

            var result = sut.CalculateInterest(months);

            Assert.That(result, Is.EqualTo(testInterest));

            cardMock.Verify(x => x.CalculateInterest(months), Times.Once);
        }

        [Test]
        [TestCase(1, 1, 1)]
        public void SumCaluclatedInterestFromMultipleCards(int months, double val1, double val2)
        {
            cardMock.Setup(x => x.CalculateInterest(months)).Returns(val1);
            var cardMock2 = new Mock<ICreditCard>();
            cardMock2.Setup(x => x.CalculateInterest(months)).Returns(val2);

            sut.Cards.Add(cardMock.Object);
            sut.Cards.Add(cardMock2.Object);

            var result = sut.CalculateInterest(months);

            Assert.That(result, Is.EqualTo(val1 + val2));
        }
    }
}
