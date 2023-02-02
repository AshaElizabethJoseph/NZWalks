using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repostories
{
    public interface IRegionRepository
    {
       IEnumerable<Region> GetAll();
    }
}
