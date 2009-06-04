using System;
using CHOJ.Abstractions;
using CHOJ.Models;
using Microsoft.Samples.Cloud.Data;

namespace CHOJ.SdsDao
{
    public class AnswerDao:BaseDao,IAnswerDao
    {
        public void SaveAnswer(Answer answer)
        {
            SsdsContainer c1 = DbContext.OpenContainer("Answer");
            c1.Insert(answer, answer.Id);
        }
    }
}