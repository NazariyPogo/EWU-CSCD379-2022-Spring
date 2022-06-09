using Microsoft.AspNetCore.Identity;

namespace Wordle.Api.Data
{
    public class AppUser : IdentityUser
    {
        public string DOB { get; internal set; }
    }
}