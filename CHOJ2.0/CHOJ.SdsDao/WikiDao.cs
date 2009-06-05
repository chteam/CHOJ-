using System;
using System.Collections.Generic;
using CHOJ.Abstractions;
using CHOJ.Models;
using Microsoft.Samples.Cloud.Data;
using System.Linq;
namespace CHOJ.SdsDao
{
    public class WikiDao:BaseDao,IWikiDao
    {
        public void Add(Wiki wiki)
        {
            SsdsContainer c1 = DbContext.OpenContainer("Wiki");
            wiki.Id = Guid.NewGuid().ToString();
            c1.Insert<Wiki>(new SsdsEntity<Wiki>
                                {
                                    Id = wiki.Id,
                                    Entity = wiki
                                });
            
        }

        public void Delete(string id)
        {
            SsdsContainer c1 = DbContext.OpenContainer("Wiki");
            c1.Delete(id);
        }

        public Wiki Get(string title)
        {
            SsdsContainer c1 = DbContext.OpenContainer("Wiki");
            return c1.Single<Wiki>(c => c.Entity.Title == title).Entity;
        }

        public IEnumerable<Wiki> List()
        {
            SsdsContainer c1 = DbContext.OpenContainer("Wiki");
            return c1.Query<Wiki>(c => true).Select(c=>c.Entity);
        }
    }
}