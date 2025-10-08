using CatalogueMvc.App.Models;
using System.ComponentModel.DataAnnotations;

namespace CatalogueMvc.App.ViewModels.Import
{
    public class ProduitImportItemVm
    {
        [Required, StringLength(100)]
        public string Nom { get; set; }

        [Required]
        public Categorie? Categorie { get; set; }

        [Required, Range(0.01, double.MaxValue)]
        public decimal Prix { get; set; }

        [Required, Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Required]
        public int LigneSource { get; set; }
    }
}
