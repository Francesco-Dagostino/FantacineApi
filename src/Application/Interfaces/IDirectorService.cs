using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDirectorService
    {
        Director AddDirector(Director director);
        Director GetDirectorById(int id);
        List<Director> GetAllDirector();
        void DeleteDirector(int id);
        void UpdateDirector(Director director);
    }
}
