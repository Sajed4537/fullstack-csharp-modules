namespace OopFundamentals.App.Exceptions
{
    [Serializable]
    internal class LivreInexistantException : Exception
    {
        public LivreInexistantException()
        {
        }

        public LivreInexistantException(string? message) : base(message)
        {
        }

        public LivreInexistantException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}