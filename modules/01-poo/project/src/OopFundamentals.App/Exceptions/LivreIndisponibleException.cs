namespace OopFundamentals.App.Exceptions
{
    [Serializable]
    internal class LivreIndisponibleException : Exception
    {
        public LivreIndisponibleException()
        {
        }

        public LivreIndisponibleException(string? message) : base(message)
        {
            
        }

        public LivreIndisponibleException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}