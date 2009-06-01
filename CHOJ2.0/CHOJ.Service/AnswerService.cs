using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CHOJ.Abstractions;
using IBatisNet.DataAccess;

namespace CHOJ.Service
{
    public class AnswerService
    {

		private static AnswerService _instance = new AnswerService();
		private IDaoManager _daoManager;
		private IAnswerDao _answerDao;



        private AnswerService() 
		{
			_daoManager = ServiceConfig.GetInstance().DaoManager;
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


    }
}
