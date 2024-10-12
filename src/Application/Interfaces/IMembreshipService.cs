using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMembershipService
    {

        //DEFINIR SI VAMOS A TENER SOLO UNA MEMBRESIA!!!
        Membership AddMembership(Membership membership);
        Membership GetMembershipById(int id);
        List<Membership> GetAllMemberships();
        void UpdateMembership(Membership membership);
        void DeleteMembership(int id);

        // Método para obtener el estado de la membresía (tipo de suscripción)
        SubscriptionType GetMembershipStatus(int id);
    }
}
