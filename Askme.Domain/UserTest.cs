using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NHibernate;
using NUnit.Framework;

namespace Askme.Domain
{
    [TestFixture,Ignore]
    public class UserTest:NHibernateInMemoryTestFixtureBase
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
            session = this.CreateSession();
        }

        [Test]
        public void TestUserHasUserId()
        {
            User user = new User("testuser");
            session.Save(user);
            IQuery query = session.CreateQuery("from User");
            IList<User> userlist = query.List<User>();
            Assert.AreEqual(1,userlist.Count);
            Assert.IsNotNull(userlist[0].UserId);
        }

        [TearDown]
        public void TestTearDown()
        {
            session.Dispose();
        }
    }
}
