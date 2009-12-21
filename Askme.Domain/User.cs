namespace Askme.Domain
{
    public class User
    {
        private string username;
        private string emailId;
        private string password;
        private string userId;

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

        public virtual string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
    }
}