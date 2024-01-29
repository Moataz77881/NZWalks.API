using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var dificulties = new List<Difficulty>()
            {
                new Difficulty{ 
                    Id = Guid.Parse("c1187031-e8e8-43cc-8efa-3baf1d0f47ff"),
                    Name="Easy"
                },
                new Difficulty{
                    Id = Guid.Parse("976e8fcf-7b8b-4a4e-97a2-2da42f0a34cd"),
                    Name="Midium"
                },
                new Difficulty{
                    Id = Guid.Parse("ee88d05d-241a-4a53-9bea-22fd2748fb0b"),
                    Name="Hard"
                }
            };

            //seed dificulties to the database
            modelBuilder.Entity<Difficulty>().HasData(dificulties);

            var region = new List<Region>
            {
                new Region{
                    Id =Guid.Parse("608edc91-d806-46d6-a3c5-52e068bfeff4"),
                    Code ="NSN",
                    Name = "Nelson",
                    RegionImageUrl = null
                },
                new Region{
                    Id =Guid.Parse("c4b91091-ccf6-4734-a6c5-8d2317dd3647"),
                    Code ="AKL",
                    Name = "Auckland",
                    RegionImageUrl = null
                },
                new Region{
                    Id =Guid.Parse("d7455aad-6419-4341-87b9-0855064af193"),
                    Code ="BOP",
                    Name = "Bay Of Plenty",
                    RegionImageUrl = null
                },
                new Region{
                    Id =Guid.Parse("48a12772-ff7a-4c80-9037-03d66152f83a"),
                    Code ="NTL",
                    Name = "Northland",
                    RegionImageUrl = null
                },
                new Region{
                    Id =Guid.Parse("46d53095-ee25-44f2-82ae-6bf7b4c8c92a"),
                    Code ="STL",
                    Name = "Southland",
                    RegionImageUrl = null
                },
                new Region{
                    Id =Guid.Parse("41dab1dc-af20-4796-9102-0220042e1dfa"),
                    Code ="WGN",
                    Name = "Wellingtion",
                    RegionImageUrl = null
                }
            };
            //seed Region data to the database
            modelBuilder.Entity<Region>().HasData(region);
        }
    }
}
