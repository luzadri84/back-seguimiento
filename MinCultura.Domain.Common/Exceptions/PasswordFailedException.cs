using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.Common.Exceptions
{
    public class PasswordFailedException : BaseException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        public PasswordFailedException(string message) : base(message)
        {
        }

    }
}
