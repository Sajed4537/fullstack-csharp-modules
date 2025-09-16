namespace SolidRefactorMovieCatalog.App.Repository.Exceptions
{
    [Serializable]
    internal class FilmInitialisationProblem : Exception
    {
        public FilmInitialisationProblem()
        {
        }

        public FilmInitialisationProblem(string? message) : base(message)
        {
        }

        public FilmInitialisationProblem(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}