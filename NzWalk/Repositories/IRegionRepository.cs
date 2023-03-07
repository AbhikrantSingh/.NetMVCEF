using NzWalk.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzWalk.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();

        Task<Region> GetAsync(Guid id);
        Task<Region> AddAsync(Region region);

        Task<Region> DeleteAsync(Guid guid);

    }
}
