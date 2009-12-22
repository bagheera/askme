namespace Askme.Domain
{
    public interface IRepository
    {
        bool SaveUser(User user);
        bool IsUserPresent(string id);
        bool SaveAnswer(Answer answer);
    }
}