namespace NZWalks.API.Models.DTO
{
    public class UpdateWalkRequest
    {
        public double Length { get; set; }
        public string Name { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }       
    }
}
