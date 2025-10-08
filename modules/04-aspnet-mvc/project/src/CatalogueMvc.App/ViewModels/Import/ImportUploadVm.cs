using System.ComponentModel.DataAnnotations;

namespace CatalogueMvc.App.ViewModels.Import
{
    public class ImportUploadVm
    {
        [Required]
        public TypeDonnee TypeDonnee { get; set; }

        
        [Required]
        public IFormFile FormFile { get; set; }

        [Required]
        public Format Format { get; set; }
    }
}
