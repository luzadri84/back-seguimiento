namespace MinCultura.Domain.Common.Exceptions
{
    public class UserDisabledException : BaseException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        public UserDisabledException(string message) : base(message)
        {
        }

    }
}
