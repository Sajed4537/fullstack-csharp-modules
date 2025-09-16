using System;

namespace ExceptionsAndValidation.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Etudiant etudiant = new Etudiant(1, "", -5, "Master 2", 15);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}