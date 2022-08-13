using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Musica.Web.Data;
using Musica.Utils;

namespace Musica.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _service;
        private readonly IConfiguration configuration;
        private readonly ILogger logger;

        public RegisterModel(UserManager<ApplicationUser> service, IConfiguration configuration, ILogger<RegisterModel> logger)
        {
            _service = service;
            
            this.configuration = configuration;
            this.logger = logger;
        }

        public IActionResult OnGet()
        {
            return RedirectToPage("Login");
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("Login");
        }
    }
}
