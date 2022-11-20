namespace Catstagram.Data.Common.Exceptions.Models
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
            : base()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}
