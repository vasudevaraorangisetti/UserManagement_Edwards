using Moq;
using NUnit.Framework;
using UserManagement.BusinessLogic;
using UserManagement.Common;
using System.Collections.Generic;

namespace UserManagement.UnitTests
{
    public class UserLogicTest
    {
        public Mock<IUserLogic> userMock = new Mock<IUserLogic>();

        [Test]
        public void Should_Return_User_List()
        {
            List<User> _userDetails = UserMockData.GetUserListForInsert();
            userMock.Setup(u => u.List()).Returns(_userDetails);
            var result = userMock.Object.List();
            Assert.True(_userDetails.Equals(result));
        }

        [Test]
        public void Should_Return_User_Details_For_Given_UserId()
        {
            userMock.Setup(u => u.Get(1)).Returns(new User { UserId = 1, FirstName = "Vasu"});
            var result = userMock.Object.Get(1);
            Assert.AreEqual("Vasu", result.FirstName);
            Assert.AreEqual(1, result.UserId);
        }

        [Test]
        public void Should_Not_Return_User_Details_For_Given_UserId()
        {
            userMock.Setup(u => u.Get(1)).Returns(new User { UserId = 1, FirstName = "Vasu" });
            var result = userMock.Object.Get(1);
            Assert.AreNotEqual("Vasu Test", result.FirstName);
            Assert.AreNotEqual(2, result.UserId);
        }

        [Test]
        public void Should_Delete_User_Details_For_Given_UserId()
        {
            List<User> _userMockData = UserMockData.GetUserListForInsert();
            userMock.Setup(u => u.List()).Returns(_userMockData);
            userMock.Setup(d => d.Delete(1)).Returns(new Response { Status = System.Net.HttpStatusCode.OK });
            var result = userMock.Object.Delete(1);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.Status);
        }
    }
}
