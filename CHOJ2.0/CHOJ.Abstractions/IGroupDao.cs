using System.Collections.Generic;
using CHOJ.Models;

namespace CHOJ.Abstractions
{
    public interface IGroupDao
    {
        IList<Group> GroupList();
        Group GetGroup(long id);
    }
}