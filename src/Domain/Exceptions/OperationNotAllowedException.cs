using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class OperationNotAllowedException : Exception
    {
        public OperationNotAllowedException()
            : base()
        {
        }

        public OperationNotAllowedException(string message)
            : base(message)
        {
        }

        public OperationNotAllowedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }


        // se usa para pasar el nombre de la operacion que no se puede hacer
        /*public OperationNotAllowedException(string operation)
            : base($"Operation {operation} is not allowed.")
        {
        }
        */
    }
}
