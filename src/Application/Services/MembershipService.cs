using Application.Interfaces;
using Application.Models;
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

        public Membership AddMembership(MembershipCreateRequest membership)
        {
            var newMembership = new Membership
            {
               
                Type = membership.Type,
                Payment = membership.Payment,
                Date = membership.Date,
                UserId = membership.UserId 
            };

            return _membershipRepository.Add(newMembership);
        }

        public Membership GetMembershipById (int id)
        {
            return _membershipRepository.GetById(id);
        }

        public List<Membership> GetAllMemberships()
        {
            return _membershipRepository.GetAll();
        }
        
        public void UpdateMembership(MembershipUpdateRequest membership)
        {
             // Buscar la membresía existente
                var existingMembership = _membershipRepository.GetById(membership.UserId);
                if (existingMembership == null)
                {
                    throw new Exception("Usuario no encontrado");
                }

                // Mapear los campos actualizados del DTO a la entidad existente
                existingMembership.Type = membership.Type;
                existingMembership.Payment = membership.Payment;
                existingMembership.Date = membership.Date;

                // Actualizar la membresía en el repositorio
                _membershipRepository.Update(existingMembership);
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
