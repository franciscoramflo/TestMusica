using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Musica.Domain.Services;
using Musica.Web.ViewModels.Song;

namespace Musica.Web.Pages.Song
{
    public class IndexModel : PageModel
    {
        private readonly SongService _service;

        public IndexModel(SongService service)
        {
            _service = service;
        }

        public JsonResult OnGetRead([DataSourceRequest] DataSourceRequest request, bool showDeleted)
        {
            var Song = (from t1 in _service.GetAll()
                             select new SongViewModel()
                             {
                                 SongId = t1.SongId,
                                 Name = t1.Name,
                                 Artist = t1.Artist,
                                 Gender = t1.Gender,
                                 Year = t1.Year,
                                 Active = t1.Active
                             }).ToList();

            if (!showDeleted)
                Song = Song.Where(p => p.Active).ToList();

            return new JsonResult(Song.ToDataSourceResult(request));

        }
    }
}
