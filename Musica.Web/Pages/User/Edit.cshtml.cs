using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Musica.Web.Data;
using Musica.Web.ViewModels.Users;
using System.Linq;
using System.Threading.Tasks;

namespace Musica.Web.Pages.User
{
    [Authorize(Roles = "Administrator")]
    public class EditModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _service;
        private IPasswordHasher<ApplicationUser> _passwordHasher;
        public EditModel(UserManager<ApplicationUser> service, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _service = service;
            _passwordHasher = passwordHasher;
        }

        [BindProperty]
        public UserEditViewModel userModel { get; set; }

        public async Task<IActionResult> OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _service.Users.Where(p => p.Id == id).FirstOrDefault();
            userModel = new UserEditViewModel()
            {
                UserId = user.Id,
                Email = user.Email,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName
            };

            userModel.IsAdministrator = await _service.IsInRoleAsync(user, ApplicationRoles.Administrator);

            if (userModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ApplicationUser user = await _service.FindByIdAsync(userModel.UserId);

            if (user != null)
            {

                user.Name = userModel.Name;
                user.UserName = userModel.UserName;
                user.NormalizedUserName = userModel.UserName.Trim().ToUpper();
                user.Email = userModel.Email;
                user.NormalizedEmail = userModel.Email != null ? userModel.Email.Trim().ToUpper() : null;
                user.PhoneNumber = userModel.PhoneNumber;

                if (!string.IsNullOrEmpty(userModel.Password))
                {
                    user.PasswordHash = _service.PasswordHasher.HashPassword(user,userModel.Password);
                }

                try
                {
                    var result = await _service.UpdateAsync(user);
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
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            else
            {
                return NotFound();
            }

        }

    }
}
