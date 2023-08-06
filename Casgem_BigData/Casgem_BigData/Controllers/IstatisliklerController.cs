using Casgem_BigData.Controllers;
using Microsoft.AspNetCore.Mvc;

public class IstatisliklerController : Controller
{
    private DefaultController defaultController = new DefaultController();

    public ActionResult Index()
    {
        int sedanPlateCount = defaultController.GetSedanPlateCount();
        int benzinPlateCount = defaultController.GetBenzinPlateCount();
        int totalCarCount = defaultController.GetTotalCarCount();
        int duzPlateCount = defaultController.GetDuzPlateCount();
        int yariOtomatikPlateCount = defaultController.GetYariOtomatikPlateCount();
        string enYayginModel = defaultController.GetMostCommonModel();

        ViewBag.SedanPlateCount = sedanPlateCount;
        ViewBag.BenzinPlateCount = benzinPlateCount;
        ViewBag.TotalCarCount = totalCarCount;
        ViewBag.DuzPlateCount = duzPlateCount;
        ViewBag.YariOtomatikPlateCount = yariOtomatikPlateCount;
        ViewBag.EnYayginModel = enYayginModel;

        return View();
    }
}
