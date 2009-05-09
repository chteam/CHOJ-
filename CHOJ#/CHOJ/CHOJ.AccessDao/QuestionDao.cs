using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using CHOJ.Abstractions;
using CHOJ.Models;

namespace CHOJ.AccessDao
{
    public class QuestionDao:BaseSqlMapDao, IQuestionDao {

        public IList<Question> AllQuestion() {
           
        }
    }
}