using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        User Create(UserCreateRequest user);   
        User GetByEmail (string email);
        User GetUserById(int id);
        List<User> GetUsers();
        void UpdateUser(int id, UserUpdateRequest user); 
        void DeleteUser(int id);
    }
}
