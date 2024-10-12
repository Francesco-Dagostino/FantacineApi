using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IBaseRepository<Director> _directorRepository;

        public DirectorService(IBaseRepository<Director> directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public Director AddDirector(Director director)
        {
            return _directorRepository.Add(director);
        }

        public Director GetDirectorById(int id)
        {
            return _directorRepository.GetById(id);
        }
        public List<Director> GetAllDirector()
        {
            return _directorRepository.GetAll();
        }
        
        public void DeleteDirector(int id)
        {
            var director = _directorRepository.GetById(id);
            if (director != null)
            {
                _directorRepository.Delete(director);
            }
            else
            {
                throw new Exception("Director no encontrado");
            }
        }

        public void UpdateDirector(Director director)
        {
            _directorRepository.Update(director);
        }
    }
}
