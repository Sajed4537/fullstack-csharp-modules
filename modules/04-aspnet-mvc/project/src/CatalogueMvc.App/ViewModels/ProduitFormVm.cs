using CatalogueMvc.App.Models;
using System.ComponentModel.DataAnnotations;

namespace CatalogueMvc.App.ViewModels
{
    public class ProduitFormVm
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nom { get; set; }

        [Required]
        public Categorie? Categorie { get; set; }

        [Required, Range(0.01, double.MaxValue)]
        public decimal Prix { get; set; }

        [Required, Range(0, double.MaxValue)]
        public int Stock { get; set; }
    }
}
