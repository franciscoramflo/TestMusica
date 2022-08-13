using Microsoft.Extensions.Logging;

using Musica.Data;
using Musica.Data.Entities;
using Musica.Data.Repositories;
using Musica.Domain.Models;
using Musica.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Musica.Domain.Services
{
    public class SongService
    {
        #region Properties

        private MusicaDBContext _context;
        private GenericRepository<Song> _repository;
        private ILogger<Song> _logger;

        #endregion

        #region Constructor

        public SongService(MusicaDBContext context, ILogger<Song> logger)
        {
            _context = context;
            _repository = new GenericRepository<Song>(context);
            _logger = logger;
        }

        #endregion

        #region Methods

        public IQueryable<SongModel> GetAll()
        {
            try
            {
                var query = from t1 in _repository.GetAll()
                            select new SongModel()
                            {
                                SongId = t1.SongId,
                                Name = t1.Name,
                                Artist = t1.Artist,
                                Gender = t1.Gender,
                                Year = t1.Year,
                                Active = t1.Active
                            };

                return query;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al traer la información de la base de datos");
                throw;
            }
        }

        public SongModel GetBy(int songId)
        {
            try
            {
                var query = from t1 in _repository.GetBy(p => p.SongId == songId)
                            select new SongModel
                            {
                                SongId = t1.SongId,
                                Name = t1.Name,
                                Artist = t1.Artist,
                                Year = t1.Year,
                                Gender = t1.Gender,
                                Active = t1.Active
                            };

                return query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un error al traer la información de la base de datos");
                throw;
            }
        }

        public ReturnInfo Create(SongModel model)
        {
            ReturnInfo returnInfo = new ReturnInfo();

            if (_repository.GetBy(p => p.Name == model.Name && p.Active).Any())
            {
                returnInfo.Result = ResultCode.Error;
                returnInfo.Message = "La canción introducida ya existe.";
                _logger.LogError(returnInfo.Message);
            }
            else
            {
                try
                {                   

                    Song entity = _repository.GetBy(p => p.Name == model.Name && !p.Active).FirstOrDefault();

                    if (entity != null)
                    {
                        entity.Artist = model.Artist;
                        entity.Gender = model.Gender;
                        entity.Year = model.Year;
                        entity.Active = true;
                        _repository.Modify(entity);
                    }
                    else
                    {
                        entity = new Song()
                        {
                            Name = model.Name,
                            Artist = model.Artist,
                            Gender = model.Gender,
                            Year = model.Year,
                            Active = true
                        };
                        _repository.Add(entity);
                    }

                    _context.SaveChanges();
                    returnInfo.Message = "Categoría agregada correctamente.";
                }
                catch (Exception ex)
                {
                    returnInfo.Result = ResultCode.Error;
                    returnInfo.Message = "Error de aplicación: Ocurrió un error al crear la canción.";
                    returnInfo.Exception = ex;
                    _logger.LogError(returnInfo.Message);
                }
            }
            return returnInfo;
        }

        public ReturnInfo Update(SongModel model)
        {
            ReturnInfo returnInfo = new ReturnInfo();

            try
            {
                Song entity = _repository.GetBy(p => p.SongId == model.SongId).FirstOrDefault();
                if (entity == null)
                {
                    returnInfo.Result = ResultCode.Error;
                    returnInfo.Message = "Error de aplicación: No se encontró ninguna canción.";
                    _logger.LogError(returnInfo.Message);
                }
                else
                {
                    entity.Name = model.Name;
                    entity.Year = model.Year;
                    entity.Gender = model.Gender;
                    entity.Artist = model.Artist;
                    entity.Active = model.Active;
                    _repository.Modify(entity);
                    _context.SaveChanges();
                    returnInfo.Message = "Canción atualizada correctamente.";

                }
            }
            catch (Exception ex)
            {
                returnInfo.Result = ResultCode.Error;
                returnInfo.Message = "Error de aplicación: Ocurrió un error al actualizar la categoría.";
                returnInfo.Exception = ex;
                _logger.LogError(returnInfo.Message);
            }

            return returnInfo;
        }

        public ReturnInfo Delete(int id)
        {
            ReturnInfo returnInfo = new ReturnInfo();

            try
            {
                Song entity = _repository.GetBy(p => p.SongId == id && p.Active).FirstOrDefault();
                if (entity == null)
                {
                    returnInfo.Result = ResultCode.Error;
                    returnInfo.Message = "Error de aplicación: No se encontró la canción.";
                    _logger.LogError(returnInfo.Message);
                }
                else
                {
                    entity.Active = false;
                    _context.SaveChanges();
                    returnInfo.Message = "Canción eliminada correctamente.";
                }
            }
            catch (Exception ex)
            {
                returnInfo.Result = ResultCode.Error;
                returnInfo.Message = "Error de aplicación: Ocurrió un error al eliminar la canción.";
                returnInfo.Exception = ex;
                _logger.LogError(returnInfo.Message);
            }

            return returnInfo;
        }



        #endregion
    }
}
