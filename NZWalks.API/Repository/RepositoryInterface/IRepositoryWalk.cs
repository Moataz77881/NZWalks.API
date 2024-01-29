using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repository.RepositoryInterface
{
    public interface IRepositoryWalk
    {
        public Task<Walk> CreateNewWalkAsync(Walk walk);
        public Task<List<Walk>> getAllWaksAsync(string? filterOn , string? filterQuery, string? orderBy, bool isDescending, int pageNumber, int pageSize);
        public Task<Walk?> getWalkById(Guid id);
        public Task<Walk?> updateWalkAsync(Guid id, Walk walk);
        public Task<Walk?> deleteWalkAsync(Guid id);
    }
}
