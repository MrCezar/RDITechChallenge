namespace RDITechChallenge.Application.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException()
            : base()
        {
        }

        public CustomerNotFoundException(string message)
            : base(message)
        {

        }
    }
}
