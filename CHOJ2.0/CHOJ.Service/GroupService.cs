using System;
using System.Collections.Generic;
using CHOJ.Abstractions;
using CHOJ.Models;
using IBatisNet.DataAccess;

namespace CHOJ.Service
{
    public class GroupService
    {
        private static GroupService _instance = new GroupService();
        private IDaoManager _daoManager;
        private IGroupDao _groupDao;



        private GroupService()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            _groupDao = (IGroupDao)_daoManager.GetDao(typeof(IGroupDao));
        }

        IGroupDao GroupDao
        {
            get { return _groupDao; }
        }

        public static GroupService GetInstance()
        {
            return _instance;
        }


       public  IEnumerable<Group> GroupList()
       {
           return GroupDao.GroupList();
       }

        public Group GetGroup(string  id)
        {
            return GroupDao.GetGroup(id);
        }

        public void Add(Group group)
        {
            GroupDao.Add(group);
        }
        public void Delete(string id)
        {
            GroupDao.Delete(id);
        }
    }
}