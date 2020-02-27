using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreditInterestCalc.Test
{
    [TestFixture]
    public class UsersShould
    {
        private Users sut;

        private Mock<IUserBuilder> userBuilderMock;
        private Mock<IUser> user1Mock;
        private Mock<IUser> user2Mock;

        private const string username1 = "name1";
        private const string username2 = "name2";

        [SetUp]
        public void Setup()
        {
            userBuilderMock = new Mock<IUserBuilder>();
            user1Mock = new Mock<IUser>();
            user2Mock = new Mock<IUser>();

            user1Mock.Setup(x => x.UserName).Returns(username1);
            user2Mock.Setup(x => x.UserName).Returns(username2);

            userBuilderMock.Setup(x => x.BuildUser(It.IsAny<string>()))
                .Returns(user1Mock.Object);

            sut = new Users(userBuilderMock.Object);
        }

        [Test]
        [TestCase("name")]
        public void UseBuilderToAddUserToPeople(string name)
        {
            sut.AddPerson(name);

            userBuilderMock.Verify(x => x.BuildUser(name), Times.Once);

            Assert.That(sut.People.Contains(user1Mock.Object));
        }

        [Test]
        public void AddWalletToUser()
        {
            sut.People.Add(user1Mock.Object);
            sut.People.Add(user2Mock.Object);

            sut.AddWalletToPerson(username1);

            user1Mock.Verify(x => x.AddWallet(), Times.Once);
            user2Mock.Verify(x => x.AddWallet(), Times.Never);
        }

        [Test]
        [TestCase(0, "cardName", 1, 1)]
        public void AddCardToWallet(int wallet, string cardName, double interest, double balance)
        {
            sut.People.Add(user1Mock.Object);
            sut.People.Add(user2Mock.Object);

            sut.AddCardToWallet(username1, wallet, cardName, interest, balance);

            user1Mock.Verify(x => x.AddCard(wallet, cardName, interest, balance), Times.Once);
            user2Mock.Verify(x => x.AddCard(wallet, cardName, interest, balance), Times.Never);
        }

        [Test]
        public void GetPersonFromPeople()
        {
            sut.People.Add(user1Mock.Object);
            sut.People.Add(user2Mock.Object);

            var result = sut.GetPerson(username1);

            Assert.That(result, Is.EqualTo(user1Mock.Object));
        }
    }
}
