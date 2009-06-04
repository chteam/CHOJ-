using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHOJ.Abstractions;
using CHOJ.Models;
using IBatisNet.DataAccess;
using IBatisNet.DataAccess.SessionStore;

namespace CHOJ.Service
{
    public class AnswerService
    {

		private static AnswerService _instance = new AnswerService();
		private IDaoManager _daoManager;
		private IAnswerDao _answerDao;



        private AnswerService() 
		{
         //   new IBatisNet.DataAccess.SessionStore.CallContextSessionStore()
         
			_daoManager = ServiceConfig.GetInstance().DaoManager;
            _daoManager.SessionStore = new HybridWebThreadSessionStore(_daoManager.Id);
             
            _answerDao = (IAnswerDao)_daoManager.GetDao(typeof(IAnswerDao));
            
		}

        IAnswerDao AnswerDao
        {
            get { return _answerDao; }
        }

        public static AnswerService GetInstance() 
		{
			return _instance;
		}
        public void SetAnswer(string questionId, string userId, int status,
			string compilerName, int useTime, int useMemory,string guid)
        {
            var answer = new Answer
                                {
                                    Id = guid,
                                    AddTime = DateTime.Now,
                                    Complier = compilerName,
                                    QuestionId = questionId,
                                    Status = status,
                                    Type = 0,
                                    UseMemory = useMemory,
                                    UserId = userId,
                                    UseTime = useTime
                                };
            AnswerDao.SaveAnswer(answer);
        }

    }
}
