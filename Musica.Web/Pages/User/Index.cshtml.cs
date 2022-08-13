
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Identity;
using Musica.Web.Data;
using Musica.Web.Classes;
using Musica.Web.ViewModels.Users;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Musica.Web.Pages.User
{
    [Authorize(Roles = "Administrator")]
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _service;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public IndexModel(UserManager<ApplicationUser> service, SignInManager<ApplicationUser> signInManager)
        {
            _service = service;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> OnGet(string id)
        {
            return Page();
        }

        public async Task<IActionResult> OnGetRead([DataSourceRequest] DataSourceRequest request, bool showDeleted)
        {
            
            var users = _service.Users.ToList();

            if (!showDeleted)
                users = users.Where(p => p.Active).ToList();

            var userList = (from u in users
                            select new UserGridViewModel()
                            {
                                UserId = u.Id,
                                Name = u.Name,
                                UserName = u.UserName,
                                Email = u.Email,
                                PhoneNumber = u.PhoneNumber,
                                Active = u.Active                              
                            }).ToList();

            foreach (var item in userList)
            {
                var user = _service.Users.Where(p => p.Id == item.UserId).FirstOrDefault();

                if (await _service.IsInRoleAsync(user, ApplicationRoles.Administrator))
                    item.Profile += "[Administrador] ";

                if (await _service.IsInRoleAsync(user, ApplicationRoles.Manager))
                    item.Profile += "[Gerencial] ";

                if (await _service.IsInRoleAsync(user, ApplicationRoles.Administrative))
                    item.Profile += "[Administrativo] ";

                if (await _service.IsInRoleAsync(user, ApplicationRoles.JefeReparto))
                    item.Profile += "[JefeReparto] ";

                if (await _service.IsInRoleAsync(user, ApplicationRoles.Operator))
                    item.Profile += "[Chofer] ";

                if (await _service.IsInRoleAsync(user, ApplicationRoles.Assistant))
                    item.Profile += "[Ayudante] ";

                if (await _service.IsInRoleAsync(user, ApplicationRoles.MusicaAux))
                    item.Profile += "[AuxiliarReparto] ";

                if (await _service.IsInRoleAsync(user, ApplicationRoles.Sales))
                    item.Profile += "[Ventas] ";

                if (await _service.IsInRoleAsync(user, ApplicationRoles.WholeSaler))
                    item.Profile += "[Almacenista] ";

                if (await _service.IsInRoleAsync(user, ApplicationRoles.SaleChief))
                    item.Profile += "[JefeVentas] ";

            }

            return new JsonResult(userList.ToDataSourceResult(request));

        }
    }
}
