using System.Collections.Generic;
using System.IO;
using Moq;
using NHibernate;
using NUnit.Framework;

namespace Askme.Domain
{
    [TestFixture,Ignore]
    public class UserTest
    {
        [Test]
        public void TestUserHasUserId()
        {
            var user = new User("testuser", "pass123", "user@foo.comsss");
            IRepository repo = Repository.GetInstance();
            repo.SaveUser(user);
            Assert.IsTrue(repo.IsUserPresent(user.UserId));
        }

        [Test]
        public void TestRegisterUser()
        {
            User user = new User("ShilpaG", "test123", "shilpa@foo.com");
            var mock = new Mock<IRepository>();
            mock.Setup(ps => ps.IsUserPresent(user.UserId)).Returns(false).AtMostOnce();
            mock.Setup(ps => ps.SaveUser(user)).Returns(true).AtMostOnce();
            Assert.IsTrue(user.Register(mock.Object));
        }
        
    }
}