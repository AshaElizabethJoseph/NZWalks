using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repostories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _nZWalksDbContext;
        public RegionRepository(NZWalksDbContext nZWalksDbContext)
        {
            this._nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await _nZWalksDbContext.AddAsync(region);
            await _nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await _nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (region == null)
                return null;

            //Delete the region
            _nZWalksDbContext.Regions.Remove(region);
            await _nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync() => await _nZWalksDbContext.Regions.ToListAsync();       
        public async Task<Region> GetAsync(Guid id) => await _nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Region> UpdateAsync(Guid id, Region regionRequest)
        {
            var region = await _nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (region == null) return null;

            region.Code= regionRequest.Code;
            region.Name= regionRequest.Name;
            region.Lat= regionRequest.Lat;
            region.Long= regionRequest.Long;
            region.Population= regionRequest.Population;

            await _nZWalksDbContext.SaveChangesAsync();

            return region;
        }
    }
}
