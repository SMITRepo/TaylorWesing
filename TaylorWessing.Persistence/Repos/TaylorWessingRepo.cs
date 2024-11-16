using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaylorWesing.Contracts.Models;
using TaylorWessing.Contracts;
using TaylorWessing.Persistence.Entities;

namespace TaylorWessing.Persistence.Repos
{
    public class TaylorWessingRepo : IAsyncRepo
    {
        public TaylorWessingRepo(TaylorWessingDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TaylorWessingDBContext _dbContext { get; }

            public async Task<Audit> CreateAsync(string url, string data)
        {
            var audit = new APIAudit { Data = data, Url = url };
            await _dbContext.AddAsync(audit);
            await _dbContext.SaveChangesAsync();
            return new Audit {Data=audit.Data, DateCreated= audit.DateCreated, Id=audit.Id, URL=audit.Url};
        }



    }
}
