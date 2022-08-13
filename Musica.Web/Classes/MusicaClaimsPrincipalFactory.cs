using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Musica.Domain.Services;
using Musica.Web.Data;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Musica.Web.Classes
{
    public class MusicaClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        //public StaffService _staffService { get; set; }

        public MusicaClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor
            //StaffService staffService
            )
            : base(userManager, roleManager, optionsAccessor)
        {
            //_staffService = staffService;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("UserName", user.Name));


            return identity;
        }
    }
}
