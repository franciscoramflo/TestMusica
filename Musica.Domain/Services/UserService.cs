using Microsoft.Extensions.Logging;

using Musica.Data;
using Musica.Data.Entities;
using Musica.Data.Repositories;
using Musica.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musica.Domain.Services
{
    public class UserService
    {
        #region Properties

        private MusicaDBContext _context;
        private GenericRepository<User> _repository;
        private ILogger<User> _logger;

        #endregion

        #region Constructor

        public UserService(MusicaDBContext context, ILogger<User> logger)
        {
            _context = context;
            _repository = new GenericRepository<User>(context);
            _logger = logger;
        }

        #endregion

        #region Methods


        #endregion
    }
}
