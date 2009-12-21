using System.Collections.Generic;
using System.IO;
using Moq;
using NHibernate;
using NUnit.Framework;

namespace Askme.Domain
{
    [TestFixture,Ignore]
    public class UserTest:NHibernateInMemoryBase
    {
        private ISession session;

        [TestFixtureSetUp]
        public void SuiteSetup()
        {
            InitalizeSessionFactory(new FileInfo("User.hbm.xml"));
        }

        [SetUp]
        public void TestSetup()
        {
            session = CreateSession();
        }

        [Test]
        public void TestUserHasUserId()
        {
            var user = new User("testuser", "pass123", "user@foo.comsss");
            session.Save(user);
            IQuery query = session.CreateQuery("from User");
            IList<User> userlist = query.List<User>();
            Assert.AreEqual(1, userlist.Count);
            Assert.IsNotNull(userlist[0].UserId);
        }

        [Test]
        public void TestRegisterUser()
        {
            User user = new User("ShilpaG", "test123", "shilpa@foo.com");
            var mock = new Mock<IRepository>();
            mock.Setup(ps => ps.FindUserById(user.UserId)).Returns(false).AtMostOnce();
            mock.Setup(ps => ps.SaveUser(user)).Returns(true).AtMostOnce();
            Assert.IsTrue(user.Register(mock.Object));
        }
        
//        [Test]
//        public void TestRegisterUserAndCheckCommunity()
//        {
//            var user = new User("DiptanuC", "test123", "diptanuc@foo.com");
//            Assert.IsTrue(user.Register());
//            Community community = Community.getInstance();
//            Assert.IsTrue(community.HasUser(user));    
//        }

        [TearDown]
        public void TestTearDown()
        {
            session.Dispose();
        }
    }
}