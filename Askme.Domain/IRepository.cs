namespace Askme.Domain
{
    public interface IRepository
    {
        void SaveUser(User user);
        bool IsUserPresent(string id);
        bool SaveAnswer(Answer answer);
    }
}