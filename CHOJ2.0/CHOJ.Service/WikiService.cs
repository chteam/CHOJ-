using System;
using System.Collections.Generic;
using CHOJ.Abstractions;
using CHOJ.Models;
using IBatisNet.DataAccess;

namespace CHOJ.Service
{
    public class WikiService
    {
          private static WikiService _instance = new WikiService();
        private IDaoManager _daoManager;
        private IWikiDao _Dao;



        private WikiService()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            _Dao = (IWikiDao)_daoManager.GetDao(typeof(IWikiDao));
        
        }

        IWikiDao WikiDao
        {
            get { return _Dao; }
        }

        public static WikiService GetInstance()
        {
            return _instance;
        }


        public void Add(Wiki wiki)
        {
            wiki.AddTime = DateTime.Now;
            WikiDao.Add(wiki);
        }

        public void Delete(string id)
        {
            WikiDao.Delete(id);
        }

        public Wiki Get(string title)
        {
            return WikiDao.Get(title);
        }

        public IEnumerable<Wiki> List()
        {
            return WikiDao.List();
        }

    }
}