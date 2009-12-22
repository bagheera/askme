using System;
using System.Collections.Generic;
using System.IO;
using NHibernate;
using NHibernate.Criterion;

namespace Askme.Domain
{
    public class Repository:NHibernateInMemoryBase,IRepository, IDisposable
    {
        private ISession session;

        private static Repository repositoryInstance;

        private Repository()
        {
            InitalizeSessionFactory(new FileInfo("User.hbm.xml"));
            session = CreateSession();
        }

        public static Repository GetInstance()
        {
            if(repositoryInstance == null)
            {
                repositoryInstance = new Repository();
            }

            return repositoryInstance;
        }

        public void SaveUser(User user)
        {
            session.Save(user);
        }

        public bool IsUserPresent(string userName)
        {
            bool userPresent = false;
            ICriteria query = session.CreateCriteria(typeof (User)).Add(Expression.Eq("Username", userName));
            IList<User> userlist = query.List<User>();
            if(userlist.Count == 1)
            {
                userPresent = true;
            }
            return userPresent;
        }


        public void Dispose()
        {
            session.Dispose();
        }
    }
}