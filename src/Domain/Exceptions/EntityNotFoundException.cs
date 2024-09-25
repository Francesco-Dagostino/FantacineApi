using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    //Esta excepción será útil cuando no encuentres una entidad (como un usuario o una película)
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
           : base()
        {
        }

        public EntityNotFoundException(string message)
            : base(message)
        {
        }

        public EntityNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public EntityNotFoundException(string entityName, object key)
            : base($"The {entityName} with key {key} was not found.")
        {
        }
    }
}
