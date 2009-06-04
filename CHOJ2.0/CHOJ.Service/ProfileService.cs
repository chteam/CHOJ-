using CHOJ.Abstractions;
using CHOJ.Models;
using IBatisNet.DataAccess;

namespace CHOJ.Service
{
    public class ProfileService
    {
        private static ProfileService _instance = new ProfileService();
        private IDaoManager _daoManager;
        private IProfileDao _Dao;



        private ProfileService()
        {
            _daoManager = ServiceConfig.GetInstance().DaoManager;
            _Dao = (IProfileDao)_daoManager.GetDao(typeof(IProfileDao));
        }

        IProfileDao ProfileDao
        {
            get { return _Dao; }
        }

        public static ProfileService GetInstance()
        {
            return _instance;
        }

        public Profile Get()
        {
            return ProfileDao.Details(HalfoxUser.OpenId, HalfoxUser.IdType);
        }

        public void Update(Profile profile)
        {
            profile.OpenId = HalfoxUser.OpenId;
            profile.IdType = HalfoxUser.IdType;
            ProfileDao.Update(profile);
            HalfoxUser.Name = profile.NickName;
        }
        public string GetNickName()
        {
            return ProfileDao.GetNickName(HalfoxUser.OpenId, HalfoxUser.IdType);
        }

    }
}