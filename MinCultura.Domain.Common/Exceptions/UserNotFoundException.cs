namespace MinCultura.Domain.Common.Exceptions
{
    public class UserNotFoundException : BaseException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Mensaje de error</param>
        public UserNotFoundException(string message) : base(message)
        {
        }

    }
}
