namespace UserService.Services
{
    public class ServiceException : System.Exception
    {
        public ServiceException(string message) : base(message)
        {

        }
    }
    public class ConflictException : ServiceException
    {
        public ConflictException(string message) : base(message)
        {

        }
    }
    public class NotFoundException : ServiceException
    {
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
