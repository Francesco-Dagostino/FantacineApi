using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Interfaces;
using OpenQA.Selenium;
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
            ValidateUserCreateRequest(user); // Método de validación separado

            // Verifica si el usuario ya existe
            var existingUser = _repository.GetByEmail(user.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already exists.");
            }

            // Crear el usuario
            var newUser = new User
            {
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
                Role = Roles.Client// Asignar rol por defecto
            };

            // Agregar el usuario al repositorio
            var createdUser = _repository.Add(newUser);
            return createdUser; // Retorna el usuario creado
        }

        // Método de validación para el DTO de creación
        private void ValidateUserCreateRequest(UserCreateRequest user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                throw new ArgumentException("All fields must be complete!");
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
            var user = GetUserById(id);


            if (user.Role != userToUpdate.Roles) user.Role = userToUpdate.Roles;

            _repository.Update(user);
        }
    }
}
