using CatalogueMvc.App.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CatalogueMvc.App.ViewModels.Paniers
{
    public class PanierCreateVm
    {
        [Required]
        public int IdUtilisateur { get; set; }

        public IEnumerable<SelectListItem> Utilisateurs { get; set; }

        public PanierCreateVm()
        {
            Utilisateurs = new List<SelectListItem>();
        }

    }
}
