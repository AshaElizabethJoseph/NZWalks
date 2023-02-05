using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repostories
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<WalkDifficulty>> GetAllAsync();
        Task<WalkDifficulty> GetAsync(Guid id);
        Task<WalkDifficulty> AddAsync(WalkDifficulty walk);
        Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walk);
        Task<WalkDifficulty> DeleteAsync(Guid id);
    }
}
