using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IMembershipRepository _membershipRepository;

        public MembershipService(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }

        public Membership AddMembership(Membership membership)
        {
            return _membershipRepository.Add(membership);
        }

        public Membership GetMembershipById (int id)
        {
            return _membershipRepository.GetById(id);
        }

        public List<Membership> GetAllMemberships()
        {
            return _membershipRepository.GetAll();
        }
        
        public void UpdateMembership(Membership membership)
        {
            _membershipRepository.Update(membership);
        }

        public void DeleteMembership(int id)
        {
            var membership = _membershipRepository.GetById(id);
            if (membership != null)
            {
                _membershipRepository.Delete(membership);
            }
            else
            {
                throw new Exception("Membresía no encontrada");
            }
        }

        // TIPO DE Membresia!!
        public SubscriptionType GetMembershipStatus(int id)
        {
            var membership = _membershipRepository.GetById(id);
            if (membership == null)
            {
                throw new Exception("Membresía no encontrada");
            }

            // Devolvemos el tipo de suscripción 
            return membership.Type;
        }

    }
}
