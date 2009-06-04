using CHOJ.Models;

namespace CHOJ.Abstractions
{
    public interface IAnswerDao
    {
        void SaveAnswer(Answer answer);
    }
}