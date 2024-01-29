using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readerRoleId = "51870929-dbfd-45c1-aef9-d15529b4b1ff";
            var writerRoleId = "1dbc524e-ade2-48cd-9b84-1d8c8e28e076";

            var role = new List<IdentityRole> {

                new IdentityRole{

                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "reader",
                    NormalizedName ="reader".ToUpper()
                },
                new IdentityRole{

                    Id=writerRoleId,
                    ConcurrencyStamp=writerRoleId,
                    Name = "writer",
                    NormalizedName = "writer".ToUpper()
                }
            };
            builder.Entity<IdentityRole>().HasData(role);
        }
    }
}
