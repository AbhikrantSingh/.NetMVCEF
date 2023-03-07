using Microsoft.EntityFrameworkCore;
using NzWalk.Data;
using NzWalk.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzWalk.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalkDbContext dbContext;
        public WalkRepository(NZWalkDbContext nZWalkDbContext)
        {
            dbContext = nZWalkDbContext;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteAsync(Guid guid)
        {
            var walk = await GetAsync(guid);
            if (walk == null)
                return null;
            dbContext.Walks.Remove(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await dbContext.Walks
                .Include(x =>x.Region)
                .Include(x=>x.WalkDifficulty)
                .ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid id)
        {
            return await dbContext.Walks
                .Include(x=>x.Region)
                .Include(x=>x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
