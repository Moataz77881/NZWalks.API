using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository.RepositoryInterface;

namespace NZWalks.API.Repository
{
    public class RepositoryWalk : IRepositoryWalk
    {
        private readonly NZWalksDbContext dbContext;

        public RepositoryWalk(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateNewWalkAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> deleteWalkAsync(Guid id)
        {
            var domain = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if(domain == null) return null;
            dbContext.Walks.Remove(domain);
            await dbContext.SaveChangesAsync();
            return domain;
        }

        public async Task<List<Walk>> getAllWaksAsync(string? filterOn, string? filterQuery, string? orderBy, bool isDescending, int pageNumber, int pageSize)
        {
            var walk = dbContext.Walks.Include("Difficulty").Include("Region");
            // filter values of walk
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false) {

                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase)) { 
                   walk = walk.Where( x => x.Name.Contains(filterQuery));
                }
            }
            //sorting 
            if (string.IsNullOrWhiteSpace(orderBy) == false) {
                if (orderBy.Equals("Name", StringComparison.OrdinalIgnoreCase)) {
                    walk = isDescending ? walk.OrderByDescending(x => x.Name) : walk.OrderBy(x => x.Name);
                }
                if (orderBy.Equals("LenghtInKm", StringComparison.OrdinalIgnoreCase)) {
                    walk = isDescending ? walk.OrderByDescending(x => x.LenghtInKm) 
                        : walk.OrderBy(x => x.LenghtInKm);
                }
            }
            //pagenation
            var skipResult = (pageNumber - 1) * pageSize;

            return await walk.Skip(skipResult).Take(pageSize).ToListAsync();
            //return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walk?> getWalkById(Guid id)
        {
            var walk = await dbContext.Walks.Include("Difficulty").Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);
            if (walk == null) return null;
            return walk;
        }

        public async Task<Walk?> updateWalkAsync(Guid id, Walk walk)
        {
            var domain = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if(domain == null) return null;

            domain.Name = walk.Name;
            domain.Description = walk.Description;
            domain.LenghtInKm = walk.LenghtInKm;
            domain.WalkImageUrl = walk.WalkImageUrl;
            domain.DifficultyId = walk.DifficultyId;
            domain.RegionId = walk.RegionId;

            await dbContext.SaveChangesAsync();
            return domain;
        }
        
    }
}
