using System.ComponentModel.DataAnnotations;

namespace FormsAndDataAnnotations.App.ViewModels
{
    public class ProduitCreateVm
    {
        [Required, MaxLength(100)]
        public string Nom {  get; set; }
        [Required]
        public string Categorie { get; set; }
        [Required, Range(1,double.MaxValue)]
        public decimal Prix { get; set; }

    }
}
