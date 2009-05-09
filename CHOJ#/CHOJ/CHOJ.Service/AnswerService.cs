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
		private DaoManager _daoManager = null;
		private IAnswerDao _accountDao = null;



        private AnswerService() 
		{
			_daoManager = ServiceConfig.GetInstance().DaoManager;
			_accountDao = (IAccountDao) _daoManager.GetDao("Account");// or daoManager["Account"]
		}

		public static AnswerService GetInstance() 
		{
			return _instance;
		}
    }
}
