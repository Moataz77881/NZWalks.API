using Microsoft.AspNetCore.Identity;

namespace NZWalks.API.Repository.RepositoryInterface
{
    public interface IRepositoryAuth
    {
        string createJWTToken(IdentityUser identityUser, List<string> roles);
    }
}
