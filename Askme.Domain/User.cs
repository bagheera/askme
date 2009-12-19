using System;

namespace Askme.Domain
{
    public class User
    {
        public User(string username)
        {
            this.Username = username;
            
        }
        public User()
        {
        }

        public virtual string Username { get; set; }

        public virtual string UserId { get; set; }
    }
}