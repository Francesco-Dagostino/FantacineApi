using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }
        public Director AddDirector(DirectorCreateRequest request)
        {
           
            var director = new Director
            {
               
                Name = request.Name,
                Description = request.Description,
                Category = request.Category
             
            };

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

        public void UpdateDirector(int DirectorId, DirectorUpdateRequest director)
        {

            var existingDirector = _directorRepository.GetById(DirectorId);
            if (existingDirector == null)
            {
                throw new Exception("Director no encontrado");
            }

            // Mapear los campos actualizados del DTO a la entidad existente
            existingDirector.Name = director.Name;
            existingDirector.Description = director.Description;
            existingDirector.Category = director.Category;


            _directorRepository.Update(existingDirector);
        }
    }
}
