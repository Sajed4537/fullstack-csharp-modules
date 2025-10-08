using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CatalogueMvc.App.ViewModels.Import
{
    public enum TypeDonnee
    {
        Produits,
        Utilisateurs
    }

    public enum Format
    {
        CSV, 
        XML
    }
    public class ImportPreviewVm
    {
        [Required]
        public TypeDonnee TypeDonnee { get; set; }
        [Required]
        public Format Format { get; set; }
        [Required]
        public int TotalLignes { get; set; }
        [Required]
        public int NbValides { get; set; }
        [Required]
        public int NbRejetees { get; set; }
        [Required]
        public IEnumerable<string> Erreurs { get; set; }

        public IEnumerable<ProduitImportItemVm> Produits { get; set; }

        public IEnumerable<UtilisateurImportItemVm> Utilisateurs { get; set; }

        public ImportPreviewVm()
        {
        }
    }
}
