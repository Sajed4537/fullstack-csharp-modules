namespace OopFundamentals.App.Exceptions
{
    [Serializable]
    internal class LivreNonEmprunteException : Exception
    {
        public LivreNonEmprunteException()
        {
        }

        public LivreNonEmprunteException(string? message) : base(message)
        {
        }

        public LivreNonEmprunteException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}