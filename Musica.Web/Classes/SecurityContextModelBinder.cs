using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Musica.Web.Classes
{
    public class SecurityContextModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException("bindingContext");
            }
            ClaimsPrincipal user = bindingContext.HttpContext.User;
            IEnumerable<Claim> claims = user.Claims;


            SecurityContext securityContext = new SecurityContext();
            securityContext.UserId = user.GetUserId();
            securityContext.UserName = user.Identity.Name;
            securityContext.Name = user.FindFirst("UserName")?.Value;

            Claim claim = user.Claims.FirstOrDefault(p => p.Type == "WarehouseId");
            if (claim != null)
            {
                securityContext.WarehouseId = int.Parse(claim.Value);
            }
            else
            {//Obtener de la cookie

            }
            bindingContext.Result = ModelBindingResult.Success(securityContext);

            return Task.CompletedTask;
        }

       
    }
}
