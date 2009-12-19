using System;

namespace Askme.Domain
{
    public class User
    {
        private string username;
        private string userId;
        
        public User(string username)
        {
            this.username = username;
            
        }
        public User()
        {
        }

        public virtual string Username
        {
            get { return username; }
            set { username = value; }
          
        }
        public virtual string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
    }
}