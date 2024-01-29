using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repository.RepositoryInterface;

namespace NZWalks.API.Repository
{
    public class RepositoryRegion : IRepositoryRegion
    {
        private readonly NZWalksDbContext dbContext;

        public RepositoryRegion(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> createRegion(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> deleteRegion(Guid id)
        {
            var region = await getRegionById(id);
            if (region == null)
            {
                return null;
            }
            dbContext.Regions.Remove(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<List<Region>> getAllRegions()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> getRegionById(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> updateRegion(Guid id, Region region)
        {
            var existingRegion = await getRegionById(id);
            if(existingRegion == null)
            {
                return null;
            };

            //map region to existing region and save the change

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();

            return existingRegion;
        }
    }
}
