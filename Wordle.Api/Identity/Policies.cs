using Microsoft.AspNetCore.Authorization;

namespace Wordle.Api.Identity;
public static class Policies
{
    public const string RandomAdmin = "RandomAdmin";
    public const string OldEnough = "OldEnough";

    public static void RandomAdminPolicy(AuthorizationPolicyBuilder policy)
    {
        policy.RequireRole(Roles.Admin);
        policy.RequireAssertion(context =>
        {
            var random = context.User.Claims.FirstOrDefault(c => c.Type == Claims.Random);
            if (Double.TryParse(random?.Value, out double result))
            {
                return result > 0.5;
            }
            return false;
        });
    }

    public static void IsOldEnoughPolicy(AuthorizationPolicyBuilder policy)
    {
        policy.RequireRole(Roles.MasterOfTheUniverse);
        policy.RequireAssertion(context =>
        {
            DateTime youngestDob = new DateTime(DateTime.Now.Year - 21, DateTime.Now.Month, DateTime.Now.Day);
            var usersDob = context.User.Claims.FirstOrDefault(x => x.Type == Claims.DOB);

            if (usersDob != null) { return false; }

            if(Convert.ToDateTime(usersDob.Value).CompareTo(youngestDob) < 0)
            {
                return true;
            }
            return false;
        });
    }
}