using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repostories
{
    public interface IRegionRepository
    {
       Task<IEnumerable<Region>> GetAllAsync();
    }
}
