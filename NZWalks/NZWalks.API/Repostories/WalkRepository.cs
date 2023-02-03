using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repostories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _nZWalksDbContext;

        public WalkRepository(NZWalksDbContext nZWalksDbContext)
        {
            this._nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id =  Guid.NewGuid();
            await _nZWalksDbContext.Walks.AddAsync(walk);
            await  _nZWalksDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var walk = await _nZWalksDbContext.Walks.FindAsync(id);

            if (walk == null) return null;

            _nZWalksDbContext.Walks.Remove(walk);
            await _nZWalksDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await _nZWalksDbContext.Walks
                .Include(x=> x.Region)
                .Include(x=> x.WalkDifficulty)
                .ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid id)
        {
            return await _nZWalksDbContext.Walks
                .Include(x=> x.Region)
                .Include(x=> x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk updateWalk)
        {
           var walk = await _nZWalksDbContext.Walks.FindAsync(id);

           if (walk == null) return null;

            walk.Length = updateWalk.Length;
            walk.Name = updateWalk.Name;
            walk.WalkDifficultyId = updateWalk.WalkDifficultyId;
            walk.RegionId= updateWalk.RegionId;

            await _nZWalksDbContext.SaveChangesAsync();
            return walk;
        }
    }
}
