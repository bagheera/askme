using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using NHibernate;
using NHibernate.Criterion;

namespace Askme.Domain
{
    public class Repository:NHibernateInMemoryBase,IRepository, IDisposable
    {
        private readonly ISession session;

        private static Repository repositoryInstance;

        private Repository()
        {
            InitalizeSessionFactory(new FileInfo("User.hbm.xml"), 
                new FileInfo("Answer.hbm.xml"),
                new FileInfo("Question.hbm.xml"),
                new FileInfo("Tag.hbm.xml"),
                new FileInfo("Vote.hbm.xml"));
            session = CreateSession();
        }


        public static Repository GetInstance()
        {
            if(repositoryInstance == null)   
                repositoryInstance = new Repository();

            return repositoryInstance;
        }

        public void SaveUser(User user)
        {
            Save(user);
        }

        public bool SaveAnswer(Answer answer)
        {
            return Save(answer);
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

        public void BeginTransaction()
        {
            session.BeginTransaction();
        }

        public void AbortTransaction()
        {
            session.Transaction.Rollback();
        }

        public void SaveQuestion(Question question)
        {
            Save(question);
        }

        public IList<Answer> LoadAnswerForQuestion(Question question)
        {
            return session.CreateQuery("from Answer where questionId = " + question.QuestionId).List<Answer>();
        }

        private bool Save<T>(T t)
        {
            session.Save(t);
            session.Flush();
            return true;
        }

        public IList<Question> SearchKeyWordInQuestion(string searchString)
        {
            ICriteria query = session.CreateCriteria(typeof(Question)).Add(Expression.Like("text", "%" + searchString + "%"));
            IList<Question> questionlist = query.List<Question>();
            return questionlist;
        }

        public IList<Answer> SearchKeyWordInAnswers(string searchString)         
        {
            ICriteria query = session.CreateCriteria(typeof(Answer)).Add(Expression.Like("text", "%" + searchString + "%"));
            IList<Answer> answerlist = query.List<Answer>();
            return answerlist;
        }

        internal bool Evict<T>(T t){
            session.Evict(t);
            return true;
        }
    }
}