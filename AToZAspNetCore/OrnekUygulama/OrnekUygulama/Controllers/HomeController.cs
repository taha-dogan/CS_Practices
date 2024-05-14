using Microsoft.AspNetCore.Mvc;
using OrnekUygulama.Models;

namespace OrnekUygulama.Controllers
{
    public class HomeController : Controller
    {

        #region ViewResult

        //public ViewResult Index()
        //{
        //    return View();
        //}

        #endregion

        #region PartialViewResult  (Sadece belirli bir alanı Ajax teknolojisi ile Client tabanlı render eder.)

        //public PartialViewResult Index()
        //{
        //    PartialViewResult result = PartialView();
        //    return result;
        //}

        #endregion

        #region JsonResult

        //public JsonResult Index()
        //{
        //    JsonResult result = Json(new Product
        //    {
        //        Id = 1,
        //        Name = "Deneme",
        //        Quantity = 10,
        //    });

        //    return Json(result);
        //}

        #endregion


    }
}
