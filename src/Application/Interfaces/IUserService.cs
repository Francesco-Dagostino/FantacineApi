using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        User RegisterUser(User user);   
        User Login(string username, string password); // ver si este metodo se usa o no!!
        User GetUserById(int id);
        List<User> GetUsers();
        void UpdateUser(User user); 
        void DeleteUser(int id);
    }
}
