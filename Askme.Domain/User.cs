using System;

namespace Askme.Domain
{
    public class User
    {
        private string username;
        private string emailId;
        private string password;
        private int userId;
        private Forum forum = new Forum();

        public User(string username, string password, string emailId)
        {
            this.username = username;
            this.password = password;
            this.emailId = emailId;
        }

        protected User()
        {
        }

        public virtual string Password
        {
            get { return password; }
            set { password = value; }
        }

        public virtual string EmailId
        {
            get { return emailId; }
            set { emailId = value; }
        }

        public virtual string Username
        {
            get { return username; }
            set { username = value; }
        }

        public virtual int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public virtual void AddQuestion(Question question)
        {
            forum.AddQuestion(question);
        }

        public virtual int NumberOfQuestion
        {
            get { return forum.Count; }
        }

        public virtual bool Register(IRepository repository)
        {
            bool userRegistered = false;
            if(!repository.IsUserPresent(this.username))
            {
                try
                {
                    repository.SaveUser(this);
                    userRegistered = true;
                }catch(Exception e)
                {
                    userRegistered = false;
                }
            }
            return userRegistered;
        }

        public virtual void AcceptSolution(Question question,Answer answer)
        {
            if (forum.HasQuestion(question))
            {
                question.AcceptSolution(answer);    
            }
            else
            {
                throw new NotSupportedException("An answer can be accepted only by the question's owner");    
            }
        }

        public virtual bool Equals(User other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.username, username) && Equals(other.emailId, emailId) && Equals(other.password, password) && other.userId == userId && Equals(other.forum, forum);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (User)) return false;
            return Equals((User) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (username != null ? username.GetHashCode() : 0);
                result = (result*397) ^ (emailId != null ? emailId.GetHashCode() : 0);
                result = (result*397) ^ (password != null ? password.GetHashCode() : 0);
                result = (result*397) ^ userId;
                result = (result*397) ^ (forum != null ? forum.GetHashCode() : 0);
                return result;
            }
        }
    }
}