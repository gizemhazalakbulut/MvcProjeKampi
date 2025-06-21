using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        [Authorize] // Bu attribute, bu controller'a erişim için kullanıcıların oturum açmış olması gerektiğini belirtir.
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }

        [HttpGet]
        public ActionResult AddCategory() // sayfa yüklendiği zaman HttpGet attribute'ı devreye girecek
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            
            CategoryValidator categoryValidator = new CategoryValidator(); // CategoryValidator sınıfından bir nesne oluşturuyoruz 
            ValidationResult results = categoryValidator.Validate(p);  // p parametresini doğrulamak için kullanıyoruz 
            if (results.IsValid) //result doğrulanmışsa ekleme yapsın 
            {
                cm.CategoryAdd(p); 
                return RedirectToAction("GetCategoryList"); 
            }
            else
            {
                foreach (var item in results.Errors) // item, doğrulama hatalarını döngü ile alıyoruz
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage); 
                }
            }
            return View();
        }

    }
}