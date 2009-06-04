using CHOJ.Models;

namespace CHOJ.Abstractions
{
    public interface IProfileDao
    {
        string Update(Profile profile);
        Profile Details(string openId,string idType);
        string GetNickName(string openId, string idType);
    }
}