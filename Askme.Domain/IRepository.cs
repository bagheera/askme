using System.Collections.Generic;

namespace Askme.Domain
{
    public interface IRepository
    {
        void SaveUser(User user);
        bool IsUserPresent(string id);
        bool SaveAnswer(Answer answer);
        IList<Question> SearchKeyWordInQuestion(string s);
        void SaveQuestion(Question question);
    }
}