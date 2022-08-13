using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Musica.Web.Data;
using Microsoft.AspNetCore.Authorization;

namespace Musica.Web.Pages.User
{
    [Authorize(Roles = "Administrator")]
    public class DeleteModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _service;
        private IPasswordHasher<ApplicationUser> _passwordHasher;

        public DeleteModel(UserManager<ApplicationUser> service)
        {
            _service = service;
        }

        public IActionResult OnGet(string id)
        {
            return NotFound();
        }

        public async Task<IActionResult> OnPost(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser user = await _service.FindByIdAsync(id);

            if (user != null)
            {

                user.Active = false;

                var result = await _service.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return new JsonResult(new { Success = true, Message = "" });
                }
                else
                {
                    return new JsonResult(new { Success = false, Message = result.Errors.ToString() });
                }
            }
            else
            {
                return new JsonResult(new { Success = false, Message = "No se encontró el usuario" });
            }
        }

        public async Task<IActionResult> OnPostUndelete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationUser user = await _service.FindByIdAsync(id);

            if (user != null)
            {

                user.Active = true;

                var result = await _service.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return new JsonResult(new { Success = true, Message = "" });
                }
                else
                {
                    return new JsonResult(new { Success = false, Message = result.Errors.ToString() });
                }
            }
            else
            {
                return new JsonResult(new { Success = false, Message = "No se encontró el usuario" });
            }
        }
    }
}

