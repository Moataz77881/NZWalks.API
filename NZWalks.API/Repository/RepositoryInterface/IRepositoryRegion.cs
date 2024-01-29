using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repository.RepositoryInterface
{
    public interface IRepositoryRegion
    {
        Task<List<Region>> getAllRegions();
        Task<Region?> getRegionById(Guid id);
        Task<Region> createRegion(Region region);
        Task<Region?> updateRegion(Guid id, Region region);
        Task<Region?> deleteRegion(Guid id);
    }
}
