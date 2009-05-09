using CHOJ.Abstractions;
using IBatisNet.DataAccess;

namespace CHOJ.Service
{
    public class QuestionService
    {
       private static QuestionService _instance = new QuestionService();
        private IDaoManager _daoManager;
        private IQuestionDao _Dao;



        private QuestionService()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            _Dao = (IQuestionDao)_daoManager.GetDao(typeof(IQuestionDao));
        }

        IQuestionDao QuestionDao
        {
            get { return _Dao; }
        }

        public static QuestionService GetInstance()
        {
            return _instance;
        }
    }
}