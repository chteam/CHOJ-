using CHOJ.Abstractions;
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

    }
}