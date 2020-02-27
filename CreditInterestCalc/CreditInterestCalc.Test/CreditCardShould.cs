using CreditInterestCalc;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class CreditCardShould
    {
        private CreditCard sut;

        private const string name = "CardName";
        private const double balance = 100;
        private const double interest = 0.15;
        private const int months = 1;

        [SetUp]
        public void Setup()
        {
            sut = new CreditCard
            {
                CardName = name,
                Balance = balance,
                InterestRate = interest
            };
        }

        [Test]
        public void CalculateInterestCorrectly()
        {
            Assert.That(sut.CalculateInterest(months), Is.EqualTo(15));
        }

        [Test]
        public void ApplyInterestCorrectly()
        {
            sut.ApplyInterest(months);
            Assert.That(sut.Balance, Is.EqualTo(115));
        }
    }
}