using System;
using CHOJ.Abstractions;
using CHOJ.Models;
using IBatisNet.DataAccess;
using System.Collections.Generic;
using IBatisNet.DataAccess.SessionStore;

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
            _daoManager.SessionStore = new HybridWebThreadSessionStore(_daoManager.Id);
        }

        IQuestionDao QuestionDao
        {
            get { return _Dao; }
        }

        public static QuestionService GetInstance()
        {
            return _instance;
        }

        public IEnumerable<Question> All()
        {
            return QuestionDao.AllQuestion();
        }
        public void Create(Question question)
        {
            question.UserId = HalfoxUser.Id;
            question.AddTime = DateTime.Now;
            
            QuestionDao.Add(question);
        }
        public void Delete(string id)
        {
            QuestionDao.Delete(id);
        }
    }
}