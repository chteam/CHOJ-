using CHOJ.Abstractions;
using CHOJ.Models;
using Microsoft.Samples.Cloud.Data;
using System;

namespace CHOJ.SdsDao
{
    public class ProfileDao:BaseDao, IProfileDao
    {

        public string Update(Profile profile)
        {
            SsdsContainer c1 = DbContext.OpenContainer("Profile");
            var p = c1.Single<Profile>(c => c.Entity.OpenId == profile.OpenId
                                            && c.Entity.IdType == profile.IdType
                );
            if (p == null)
            {
                profile.LogOnTime = DateTime.Now;
                profile.RegisterTime = DateTime.Now;
                profile.Role = "User";
                c1.Insert(new SsdsEntity<Profile>
                                       {
                                           Id = Guid.NewGuid().ToString(),
                                           Kind = "Profile",
                                           Entity = profile,
                                       });
            }
            else
            {
                var newp = p.Entity;
                newp.Name = profile.Name;
                newp.NickName = profile.NickName;
                newp.School = profile.School;
                newp.SchoolDetails = profile.SchoolDetails;
                newp.Sex = profile.Sex;
                c1.Update(newp, p.Id, ConcurrencyPattern.IfNoneMatch);
            }
            return "";
        }

        public Profile Details(string openId, string idType)
        {
            SsdsContainer c1 = DbContext.OpenContainer("Profile");
            var ret= c1.Single<Profile>(c => c.Entity.IdType == idType && c.Entity.OpenId == openId);
            if (ret == null)
                return null;
            return ret.Entity;
        }

        public string GetNickName(string openId, string idType)
        {
            var x = Details(openId, idType);
            return x == null ? "Œ¥ªÒ»°" : x.NickName;
        }
    }
}