using CatalogueMvc.App.ViewModels.Import;

namespace CatalogueMvc.App.Services.ImportServices
{
    public interface IFileParser
    {
        public ImportPreviewVm Parse(ImportUploadVm importUpload);
    }
}
