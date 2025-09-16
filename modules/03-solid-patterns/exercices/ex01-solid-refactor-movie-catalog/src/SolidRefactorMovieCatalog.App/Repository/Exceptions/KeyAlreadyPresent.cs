namespace SolidRefactorMovieCatalog.App.Repository.Exceptions
{
    [Serializable]
    internal class KeyAlreadyPresent : Exception
    {
        public KeyAlreadyPresent()
        {
        }

        public KeyAlreadyPresent(string? message) : base(message)
        {
        }

        public KeyAlreadyPresent(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}