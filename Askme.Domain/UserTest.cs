using System;
using System.Collections.Generic;
using System.IO;
using Moq;
using NHibernate;
using NUnit.Framework;

namespace Askme.Domain
{
    [TestFixture]
    public class UserTest
    {
        [Test, Ignore]
        public void TestUserCreation()
        {
            var user = new User("testuser", "pass123", "user@foo.comsss");
            IRepository repo = Repository.GetInstance();
            repo.SaveUser(user);
            Assert.IsTrue(repo.IsUserPresent(user.Username));
        }

        [Test]
        public void TestUserRegistrationIfUserNotPresent()
        {
            User user = new User("ShilpaG", "test123", "shilpa@foo.com");
            var mock = new Mock<IRepository>();
            mock.Setup(ps => ps.IsUserPresent(user.Username)).Returns(false).AtMostOnce();
            Assert.IsTrue(user.Register(mock.Object));
            mock.VerifyAll();
        }

        [Test]
        public void TestUserRegistrationIfUserAlreadyPresent()
        {
            User user = new User("ShilpaG", "test123", "shilpa@foo.com");
            var mock = new Mock<IRepository>();
            mock.Setup(ps => ps.IsUserPresent(user.Username)).Returns(true).AtMostOnce();
            Assert.IsFalse(user.Register(mock.Object));
            mock.VerifyAll();
        }

        [Test]
        public void TestFailUsersRegistrationIfSaveUserThrowsException()
        {
            User user = new User("ShilpaG", "test123", "shilpa@foo.com");
            var mock = new Mock<IRepository>();
            mock.Setup(ps => ps.IsUserPresent(user.Username)).Returns(false).AtMostOnce();
            mock.Setup(ps => ps.SaveUser(user)).Throws(new Exception("User could not be saved")).AtMostOnce();
            user.Register(mock.Object);
        }
        
    }
}