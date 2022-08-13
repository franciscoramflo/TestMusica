using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Musica.Domain.Models;
using Musica.Domain.Services;
using Musica.Utils;
using Musica.Web.Classes;
using Musica.Web.ViewModels.Song;

namespace Musica.Web.Pages.Song
{
    [Authorize(Roles = "Administrator")]
    public class CreateModel : PageModel
    {
        private readonly SongService _service;
        public CreateModel(SongService service)
        {
            _service = service;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public SongViewModel Song { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ReturnInfo returnInfo = new ReturnInfo();

            if (returnInfo.Result == ResultCode.Success)
            {
                returnInfo = _service.Create(new SongModel
                {
                    Name = Song.Name,
                    Artist = Song.Artist,
                    Year = Song.Year,
                    Gender = Song.Gender,
                    Active = true
                });

                if (returnInfo.Result == ResultCode.Success)
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    ModelState.AddModelError("", returnInfo.Message);
                    return Page();
                }
            }
            else
            {
                ModelState.AddModelError("", returnInfo.Message);

                return Page();
            }

        }
    }
}
