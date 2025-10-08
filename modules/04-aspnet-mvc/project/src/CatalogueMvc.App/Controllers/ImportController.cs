using CatalogueMvc.App.Models;
using CatalogueMvc.App.Services.ImportServices;
using CatalogueMvc.App.ViewModels.Import;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using CatalogueMvc.App.Services.Repositories;

namespace CatalogueMvc.App.Controllers
{
    public class ImportController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public ImportController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public IActionResult Upload(TypeDonnee typeDonnee, Format format)
        {
            var vm = new ImportUploadVm();
            vm.Format = format;
            vm.TypeDonnee = typeDonnee;
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Upload(ImportUploadVm vm)
        {
            if (vm.FormFile == null || vm.FormFile.Length == 0)
            {
                TempData["message"] = "Le fichier est invalide ou vide.";
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                TempData["message"] = "Modèle d’import invalide.";
                return View("Index", vm);
            }

            var ext = Path.GetExtension(vm.FormFile.FileName).ToLowerInvariant();
            if (ext != ".csv" && ext != ".xml")
            {
                TempData["message"] = "Extension invalide. Seuls .csv ou .xml sont acceptés.";
                return RedirectToAction("Index");
            }

            if (vm.FormFile.Length > 5 * 1024 * 1024)
            {
                TempData["message"] = "Le fichier est trop volumineux.";
                return RedirectToAction("Index");
            }
            IFileParser fileParser = null;

            switch (vm.Format, vm.TypeDonnee)
            {
                case (Format.CSV, TypeDonnee.Utilisateurs):
                    fileParser = new CsvUserParser();
                    break;
                case (Format.CSV, TypeDonnee.Produits):
                    fileParser = new CsvProductParser();
                    break;
                case (Format.XML, TypeDonnee.Utilisateurs):
                    fileParser = new XmlUserParser();
                    break;
                case (Format.XML, TypeDonnee.Produits):
                    fileParser = new XmlProductParser();
                    break;
                default:
                    TempData["message"] = "Couple (format/type) non supporté.";
                    return RedirectToAction("Index");
            }

            var vmPreview = fileParser.Parse(vm);

            if (vm.TypeDonnee == TypeDonnee.Produits)
            {
                var jsonValides = JsonSerializer.Serialize(vmPreview.Produits ?? Enumerable.Empty<ProduitImportItemVm>());

                HttpContext.Session.SetString("IMPORT_PRODUITS_VALIDES", jsonValides);
            }
            else
            {
                var jsonValides = JsonSerializer.Serialize(vmPreview.Utilisateurs ?? Enumerable.Empty<UtilisateurImportItemVm>());

                HttpContext.Session.SetString("IMPORT_UTILISATEURS_VALIDES", jsonValides);
            }

            HttpContext.Session.SetString("IMPORT_PREVIEW_TOTAL", vmPreview.TotalLignes.ToString());
            HttpContext.Session.SetString("IMPORT_PREVIEW_VALIDES", vmPreview.NbValides.ToString());
            HttpContext.Session.SetString("IMPORT_PREVIEW_REJETEES", vmPreview.NbRejetees.ToString());

            return View("Preview", vmPreview);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Confirm(TypeDonnee type)
        {
            int totalPreview = int.TryParse(HttpContext.Session.GetString("IMPORT_PREVIEW_TOTAL"), out var t) ? t : 0;
            int validesPreview = int.TryParse(HttpContext.Session.GetString("IMPORT_PREVIEW_VALIDES"), out var v) ? v : 0;
            int rejeteesPreview = int.TryParse(HttpContext.Session.GetString("IMPORT_PREVIEW_REJETEES"), out var r) ? r : 0;

            int ajoutes = 0;
            int ignoresConfirm = 0;

            if (type == TypeDonnee.Produits)
            {
                var json = HttpContext.Session.GetString("IMPORT_PRODUITS_VALIDES");
                if (string.IsNullOrEmpty(json))
                {
                    TempData["message"] = "La session d’import a expiré. Merci de recommencer.";
                    return RedirectToAction("Index");
                }

                var items = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ProduitImportItemVm>>(json) ?? Enumerable.Empty<ProduitImportItemVm>();

                var existants = _unitOfWork.Produits.ListAll().ToList();

                foreach (var it in items)
                {
                    if (string.IsNullOrWhiteSpace(it.Nom))
                    {
                        ignoresConfirm++;
                        continue;
                    }

                    bool doublon = existants.Any(p =>p.Nom.Equals(it.Nom.Trim(), StringComparison.OrdinalIgnoreCase));

                    if (doublon || it.Prix < 0 || it.Stock < 0)
                    {
                        ignoresConfirm++;
                        continue;
                    }

                    var entity = new Produit
                    {
                        Nom = it.Nom.Trim(),
                        Categorie = it.Categorie.Value,
                        Prix = it.Prix,
                        Stock = it.Stock
                    };

                    _unitOfWork.Produits.Add(entity);
                    ajoutes++;

                    existants.Add(entity);
                }

                _unitOfWork.SaveChanges();

                HttpContext.Session.Remove("IMPORT_PRODUITS_VALIDES");
                HttpContext.Session.Remove("IMPORT_PREVIEW_TOTAL");
                HttpContext.Session.Remove("IMPORT_PREVIEW_VALIDES");
                HttpContext.Session.Remove("IMPORT_PREVIEW_REJETEES");

                int ignoresTotal = rejeteesPreview + ignoresConfirm;

                TempData["message"] = $"Import produits terminé : {ajoutes} ajoutés, {ignoresTotal} ignorés (dont {rejeteesPreview} rejetés au parsing).";

                return RedirectToAction("Done");
            }
            else
            {
                var json = HttpContext.Session.GetString("IMPORT_UTILISATEURS_VALIDES");
                if (string.IsNullOrEmpty(json))
                {
                    TempData["message"] = "La session d’import a expiré. Merci de recommencer.";
                    return RedirectToAction("Index");
                }

                var items = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<UtilisateurImportItemVm>>(json) ?? Enumerable.Empty<UtilisateurImportItemVm>();

                var existants = _unitOfWork.Utilisateurs.ListAll().ToList();

                foreach (var it in items)
                {
                    if (string.IsNullOrWhiteSpace(it.Email) || string.IsNullOrWhiteSpace(it.Nom) || string.IsNullOrWhiteSpace(it.Prenom))
                    {
                        ignoresConfirm++;
                        continue;
                    }

                    var emailNorm = it.Email.Trim().ToLowerInvariant();

                    bool doublon = existants.Any(u =>(u.Email ?? string.Empty).Trim().ToLowerInvariant() == emailNorm);

                    if (doublon)
                    {
                        ignoresConfirm++;
                        continue;
                    }

                    var entity = new Utilisateur
                    {
                        Nom = it.Nom.Trim(),
                        Prenom = it.Prenom.Trim(),
                        Email = it.Email.Trim(),
                        Type = it.Type
                    };

                    _unitOfWork.Utilisateurs.Add(entity);
                    ajoutes++;

                    existants.Add(entity);
                }

                _unitOfWork.SaveChanges();

                HttpContext.Session.Remove("IMPORT_UTILISATEURS_VALIDES");
                HttpContext.Session.Remove("IMPORT_PREVIEW_TOTAL");
                HttpContext.Session.Remove("IMPORT_PREVIEW_VALIDES");
                HttpContext.Session.Remove("IMPORT_PREVIEW_REJETEES");

                int ignoresTotal = rejeteesPreview + ignoresConfirm;

                TempData["message"] = $"Import utilisateurs terminé : {ajoutes} ajoutés, {ignoresTotal} ignorés (dont {rejeteesPreview} rejetés au parsing).";

                return RedirectToAction("Done");
            }
        }



        [HttpGet]
        public IActionResult Done()
        {
            return View();
        }
    }
}
