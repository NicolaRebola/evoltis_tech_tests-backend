namespace TechnicalTests.Api.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message)
            : base(message)
        {
        }
    }
}
