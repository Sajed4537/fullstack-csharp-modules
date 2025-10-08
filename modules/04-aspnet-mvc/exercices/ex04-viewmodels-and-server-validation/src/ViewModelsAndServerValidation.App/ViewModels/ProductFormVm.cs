using System.ComponentModel.DataAnnotations;
using ViewModelsAndServerValidation.App.Models;

namespace ViewModelsAndServerValidation.App.ViewModels
{
    public class ProductFormVm
    {
        public int? Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public Categorie? Categorie { get; set; }

        [Required, Range(0.01, double.MaxValue)]
        public decimal Prix { get; set; }
    }
}
