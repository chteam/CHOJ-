using System.Collections.Generic;
using CHOJ.Models;

namespace CHOJ.Abstractions
{
    public interface IQuestionDao
    {
        IList<Question> AllQuestion();
    }
}