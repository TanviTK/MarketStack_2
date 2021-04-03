using MarketStack_2.Helpers;
using MarketStack_2.Helpers.DatabaseLinkCalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MarketStack_2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public JsonResult ReadEndOfTheDayData(string tickers)
        {
            var databaseCalls = new DatabaseCalls();
            var eod_Root = ExternalApiCalls.CallExternalAPIForEndOfDayData(tickers);
            var eod_Id = databaseCalls.PostEODPagination(eod_Root.pagination);
            databaseCalls.PostEODData(eod_Root.data, eod_Id);


            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReadHistoricData(string tickers, DateTime fromDate, DateTime toDate)
        {
            var databaseCalls = new DatabaseCalls();
            var hd_Root = ExternalApiCalls.CallExternalAPIForHistoricData(tickers, fromDate, toDate);
            var hd_Id = databaseCalls.PostHistoricPagination(hd_Root.pagination);
            databaseCalls.PostHistoricData(hd_Root.data, hd_Id);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ReadIntraData(string tickers)
        {
            var databaseCalls = new DatabaseCalls();
            var iDay_Root = ExternalApiCalls.CallIntradayData(tickers);
            var iDay_Id = databaseCalls.PostIntraDayPagination(iDay_Root.pagination);
            databaseCalls.PostIntraDayData(iDay_Root.data, iDay_Id);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}
