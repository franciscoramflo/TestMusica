using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using Musica.Domain.Models;
using Musica.Domain.Services;
using Musica.Utils;
using Musica.Web.ViewModels.Song;

namespace Musica.Web.Pages.Song
{
    [Authorize(Roles = "Administrator")]
    public class EditModel : PageModel
    {
        private readonly SongService _service;

        public EditModel(SongService service)
        {
            _service = service;
        }

        [BindProperty]
        public SongViewModel Song { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var SongModel = _service.GetBy(id.Value);
            Song = new SongViewModel()
            {
                SongId = SongModel.SongId,
                Name = SongModel.Name,
                Artist = SongModel.Artist,
                Year = SongModel.Year,
                Gender = SongModel.Gender,
                Active = SongModel.Active
            };

            if (Song == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostSong()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SongModel SongModel = new SongModel();
            SongModel.SongId = Song.SongId;
            SongModel.Name = Song.Name;
            SongModel.Artist = Song.Artist;
            SongModel.Year = Song.Year;
            SongModel.Gender = Song.Gender;
            SongModel.Active = Song.Active;

            ReturnInfo returnInfo = new ReturnInfo();
            try
            {
                returnInfo = _service.Update(SongModel);
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
            catch (DbUpdateConcurrencyException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return Page();
        }
    }
}
