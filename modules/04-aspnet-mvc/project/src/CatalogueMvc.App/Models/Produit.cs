using System.ComponentModel.DataAnnotations;

namespace CatalogueMvc.App.Models
{
    public enum Categorie
    {
        [Display(Name = "Alimentation")] Alimentation,
        [Display(Name = "Hygiene et beauté")] HygieneEtBeaute,
        [Display(Name = "Entretien maison")] EntretienMaison,
        [Display(Name = "Equipement maison")] EquipementMaison,
        [Display(Name = "Textile et habillement")] TextileEtHabillement,
        [Display(Name = "Enfants et bébés")] EnfantsEtBebes,
        [Display(Name = "Multimédia et loisirs")] MultimediaEtLoisirs,
        [Display(Name = "Animalerie")] Animalerie
    }
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public Categorie Categorie { get; set; }
        public int Stock { get; set; }
    }
}
