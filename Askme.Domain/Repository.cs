using System;
using System.Collections.Generic;
using System.IO;
using NHibernate;

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

        public bool SaveUser(User user)
        {
            session.Save(user);
            return true;
        }

        public bool IsUserPresent(string id)
        {
            bool userPresent = false;
            IQuery query = session.CreateQuery("from User where UserId=" + id);
            IList<User> userlist = query.List<User>();
            if(userlist.Count > 0)
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