using Microsoft.EntityFrameworkCore;
using NzWalk.Data;
using NzWalk.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzWalk.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalkDbContext dbContext;
        public RegionRepository(NZWalkDbContext nZWalkDbContext)
        {
            dbContext = nZWalkDbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid guid)
        {
            var region = await GetAsync(guid);
            if (region == null)
                return null;
            dbContext.Regions.Remove(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
