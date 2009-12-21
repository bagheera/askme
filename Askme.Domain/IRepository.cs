namespace Askme.Domain
{
    public interface IRepository
    {
        bool SaveUser(User user);
        bool FindUserById(string id);
    }
}