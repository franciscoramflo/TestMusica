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
    public class DeleteModel : PageModel
    {
        private readonly SongService _service;

        public DeleteModel(SongService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return NotFound();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            ReturnInfo returnInfo = new ReturnInfo();
            try
            {
                returnInfo = _service.Delete(id);
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

        public async Task<IActionResult> OnPostUndelete(int id)
        {
            SongModel Song = _service.GetBy(id);

            if (Song != null)
            {

                Song.Active = true;

                var returnInfo = _service.Update(Song);
                if (returnInfo.Result == ResultCode.Success)
                {
                    return new JsonResult(new { Success = true, Message = "" });
                }
                else
                {
                    return new JsonResult(new { Success = false, Message = returnInfo.Message });
                }
            }
            else
            {
                return new JsonResult(new { Success = false, Message = "No se encontró el registro" });
            }
        }
    }
}
