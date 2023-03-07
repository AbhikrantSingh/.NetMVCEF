using Microsoft.EntityFrameworkCore;
using NzWalk.Data;
using NzWalk.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzWalk.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalkDbContext dbContext;
        public WalkDifficultyRepository(NZWalkDbContext nZWalkDbContext)
        {
            dbContext = nZWalkDbContext;
        }

        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();
            await dbContext.WalkDifficulty.AddAsync(walkDifficulty);
            await dbContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid guid)
        {
            var walkDifficulty = await GetAsync(guid);
            if (walkDifficulty == null)
                return null;
            dbContext.WalkDifficulty.Remove(walkDifficulty);
            await dbContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await dbContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> GetAsync(Guid id)
        {
            return await dbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
