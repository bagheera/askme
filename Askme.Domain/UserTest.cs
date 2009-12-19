using System.Collections.Generic;
using System.IO;
using NHibernate;
using NUnit.Framework;

namespace Askme.Domain
{
    [TestFixture]
    public class UserTest : NHibernateInMemoryTestFixtureBase
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
            User user = new User("testuser");
            session.Save(user);
            IQuery query = session.CreateQuery("from User");
            IList<User> userlist = query.List<User>();
            Assert.AreEqual(1, userlist.Count);
            Assert.IsNotNull(userlist[0].UserId);
        }

        [TearDown]
        public void TestTearDown()
        {
            session.Dispose();
        }
    }
}