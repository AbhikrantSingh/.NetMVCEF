using NzWalk.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzWalk.Repositories
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync();

        Task<Walk> GetAsync(Guid id);
        Task<Walk> AddAsync(Walk walk);

        Task<Walk> DeleteAsync(Guid guid);

    }
}
