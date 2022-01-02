using PersonalProjectBookLibraryApi.Model;
using System.Collections.Generic;

namespace PersonalProjectBookLibraryApi.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(AppUser user, List<string> userRoles);

    }
}
