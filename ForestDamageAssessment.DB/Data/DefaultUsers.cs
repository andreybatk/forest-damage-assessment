using Microsoft.AspNetCore.Identity;

namespace ForestDamageAssessment.DB.Data
{
    public static class DefaultUsers
    {
        public static readonly IdentityUser Administrator = new IdentityUser
        {
            Email = "Admin@mail.ru",
            EmailConfirmed = true,
            UserName = "Admin@mail.ru"
        };
        public static readonly IdentityUser User = new IdentityUser
        {
            Email = "User@mail.ru",
            EmailConfirmed = true,
            UserName = "User@mail.ru"
        };
    }
}