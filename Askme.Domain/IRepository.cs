using System.Collections.Generic;

namespace Askme.Domain
{
    public interface IRepository
    {
        void SaveUser(User user);
        bool IsUserPresent(string id);
        bool SaveAnswer(Answer answer);
        void BeginTransaction();
        void AbortTransaction();
        void SaveQuestion(Question question);
        IList<Answer> LoadAnswerForQuestion(Question question);
    }
}