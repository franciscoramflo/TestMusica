using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

using Musica.Domain.Services;
using Musica.Web.Pages.User;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Musica.Web.Classes
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
        
        public static string GetUserName(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst("UserName")?.Value;
        }

        public static int? GetWarehouseId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            string warehouseId = "";
            if (principal.FindFirst("WarehouseId") != null)
                warehouseId=principal.FindFirst("WarehouseId").Value;

            if (!string.IsNullOrEmpty(warehouseId))
            {
                return int.Parse(warehouseId);                
            }
            else
            {
                return null;
            }
        }

        public static string GetWarehouseName(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            var claim=principal.FindFirst("WarehouseName");
            if (claim != null) 
            {
                return claim.Value;
            }
            return "Sin Almacén";
        }       

        public static async void AddUpdateClaim(this IPrincipal currentPrincipal, string key, string value, IHttpContextAccessor http)
        {
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
                return;

            // check for existing claim and remove it
            var existingClaim = identity.FindFirst(key);
            if (existingClaim != null)
                identity.RemoveClaim(existingClaim);

            // add new claim
            identity.AddClaim(new Claim(key, value));
            await http.HttpContext.SignInAsync(new ClaimsPrincipal(identity),new AuthenticationProperties() { IsPersistent=true });
        }

        public static string GetClaimValue(this IPrincipal currentPrincipal, string key)
        {
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
                return null;

            var claim = identity.Claims.FirstOrDefault(c => c.Type == key);
            return claim.Value;
        }
    }
}
