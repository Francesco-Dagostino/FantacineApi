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
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _repository;

        public UserService(IBaseRepository<User> repository)
        {
            _repository = repository;
        }

        public User RegisterUser(User user)
        {
            //validar antes de agregar el usuario
            return _repository.Add(user);
        }

        public User GetUserById(int id)
        {
            // Obtener usuario por ID
            return _repository.GetById(id);
        }

        public List<User> GetUsers()
        {
            return _repository.GetAll(); 
        }

        public void UpdateUser(User user)
        {
            // Actualizar usuario
            _repository.Update(user);
        }

        public void DeleteUser(int id)
        {
            var user = _repository.GetById(id); // Cambié _userRepository a _repository
            if (user != null)
            {
                _repository.Delete(user); // Cambié _userRepository a _repository
            }
            else
            {
                throw new Exception("Usuario no encontrado");
            }
        }

        public User Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
