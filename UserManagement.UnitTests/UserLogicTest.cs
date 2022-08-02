using System;
using Moq;
using FluentAssertions;
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
        public void Should_Insert_User_Data()
        {
            //List<User> _userMockData = UserMockData.GetUserListForInsert();
            //userMock.Setup(u => u.List()).Returns(_userMockData);
            //UserLogic userLogicObject = new UserLogic(userMock.Object);
            //var result = userLogicObject.List();
            //Assert.True(_userMockData.Equals(result));
        }
    }
}
