using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using Musica.Domain.Services;
using Musica.Web.Data;

namespace Musica.Web.Pages.User
{
    public class ComboModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _service;

        public ComboModel(UserManager<ApplicationUser> service)
        {
            _service = service;
        }
        public IActionResult OnGet(string text)
        {
            var Users = (from w in _service.Users
                                 where w.Active
                                 select new SelectListItem()
                                 {
                                     Text = w.Name,
                                     Value = w.Id
                                 }).OrderBy(a => a.Text).ToList();
            if (!string.IsNullOrEmpty(text))
                Users = Users.Where(a => a.Text.Trim().ToUpper().Contains(text.Trim().ToUpper())).OrderBy(a => a.Text).ToList();

            return new JsonResult(Users);
        }
    }
}
