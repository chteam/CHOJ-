using IBatisNet.DataAccess.Interfaces;
using Microsoft.Samples.Cloud.Data;

namespace CHOJ.SdsDao
{
    public class BaseDao:IDao
    {
        private SsdsContext _dbContext;
        public SsdsContext DbContext
        {
            get
            {
                if(_dbContext==null)
                {
                    _dbContext = new SsdsContext(
                        "authority=https://choj.data.database.windows.net/v1/;username=chsword;password=77298666"
                        );
                }
                return _dbContext;
            }
        }
    }
}