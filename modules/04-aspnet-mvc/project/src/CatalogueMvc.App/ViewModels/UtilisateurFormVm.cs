using CatalogueMvc.App.Models;
using System.ComponentModel.DataAnnotations;

namespace CatalogueMvc.App.ViewModels
{
    public class UtilisateurFormVm
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nom { get; set; }

        [Required, StringLength(100)]
        public string Prenom { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public TypeUtilisateur Type { get; set; }
    }
}
