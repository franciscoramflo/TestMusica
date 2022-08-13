
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using System;
using System.Linq;
using Musica.Web.Data;
using Musica.Web.ViewModels.Users;
using Musica.Web.Classes;
using Microsoft.AspNetCore.Authorization;
using Musica.Utils;
using Musica.Domain.Services;

namespace Musica.Web.Pages.User
{
    [Authorize(Roles = "Administrator")]
    public class CreateModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _service;
        private readonly UserService _serviceUser;

        public CreateModel(UserManager<ApplicationUser> service,UserService userService)
        {
            _service = service;
            _serviceUser = userService;
        }

        public IActionResult OnGet()
        {
            userModel = new UserCreateViewModel();
            return Page();
        }

        [BindProperty]
        public UserCreateViewModel userModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ApplicationUser user = new ApplicationUser()
            {
                Name = userModel.Name,
                UserName = userModel.UserName,
                NormalizedUserName = userModel.UserName.Trim().ToUpper(),
                Email = userModel.Email,
                NormalizedEmail = userModel.Email != null ? userModel.Email.Trim().ToUpper() : null,
                Active = true,
                EmailConfirmed = true,
                PhoneNumber = userModel.PhoneNumber
            };
            
            var myUser = _service.Users.Where(p => p.Id == User.GetUserId()).FirstOrDefault();

            var result = await _service.CreateAsync(user, userModel.Password);

           
            if (result.Succeeded)
            {

                if (userModel.IsAdministrator)
                {
                    await _service.AddToRoleAsync(user, ApplicationRoles.Administrator);
                }
                else
                {
                    await _service.RemoveFromRoleAsync(user, ApplicationRoles.Administrator);
                }

                

                return RedirectToPage("./Index");
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                    ModelState.AddModelError("", error.Description);
                return Page();
            }
        }
    }
}