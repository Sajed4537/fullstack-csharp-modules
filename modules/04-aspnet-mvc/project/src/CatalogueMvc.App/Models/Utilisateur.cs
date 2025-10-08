namespace CatalogueMvc.App.Models
{
    public enum TypeUtilisateur { Administrateur, Client }
    public class Utilisateur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public TypeUtilisateur Type { get; set; }

    }
}
