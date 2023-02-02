using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repostories
{
    public class RegionRepository : IRegionRepository
    {
        private NZWalksDbContext _nZWalksDbContext;
        public RegionRepository(NZWalksDbContext nZWalksDbContext)
        {
            this._nZWalksDbContext = nZWalksDbContext;
        }
        public IEnumerable<Region> GetAll()
        {
            return _nZWalksDbContext.Regions.ToList();
        }
    }
}
