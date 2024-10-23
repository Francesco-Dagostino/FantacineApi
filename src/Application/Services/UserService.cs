using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
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
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Create(UserCreateRequest user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                throw new ArgumentException("All fiels must be complet!");

            var isUserExist = _repository.GetByEmail(user.Email);

            if (isUserExist != null)
            {
                throw new Exception("No se puede repetir Email");
            }

            var usuario = new User
            {
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
            };

            return _repository.Add(usuario);
        }

        public User GetUserById(int id)
        {
            var obj = _repository.GetById(id) ?? throw new ArgumentNullException(nameof(GetUserById));
            return obj;
        }

        public List<User> GetUsers()
        {
            return _repository.GetAll();
        }

        public User GetByEmail(string email)
        {
            var user = _repository.GetByEmail(email) ?? throw new ArgumentNullException(nameof(email));
            return (User)user;
        }

        public void UpdateUser(int id, UserUpdateRequest user)
        {
            var usuario = _repository.GetById(id) ?? throw new EntityNotFoundException(typeof(User).ToString(), id);

            if (user.Name != null) usuario.Name = user.Name;
            if (user.Password != null) usuario.Password = user.Password;

            _repository.Update(usuario);
        }

        public void DeleteUser(int id)
        {
            var user = _repository.GetById(id) ?? throw new ArgumentNullException(nameof(id));
            _repository.Delete(user);
        }

        //Roles..
        public void UpdateRole(int id, SuperAdminUserUpdateRequest userToUpdate)
        {
            var userRequestingChange = GetUserById(id);
            // Solo el SuperAdmin puede cambiar roles
            if (userRequestingChange.Role != Roles.SuperAdmin)
            {
                throw new UnauthorizedAccessException("Only SuperAdmin can change roles.");
            }

            var userToBeUpdated = GetUserById(userToUpdate.UserId);

            // Si el rol es diferente, lo actualizamos
            if (userToBeUpdated.Role != userToUpdate.Roles)
            {
                userToBeUpdated.Role = userToUpdate.Roles;
                _repository.Update(userToBeUpdated);
            }
            else
            {
                throw new Exception("The user already has this role.");
            }
        }
    }
}
