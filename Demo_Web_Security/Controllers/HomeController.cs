using Demo_Web_Security.DTO;
using Demo_Web_Security.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo_Web_Security.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static int currentMoney = 10000000;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.price = currentMoney;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Transfer(TransferDTO dto)
        {
            currentMoney = currentMoney - dto.price;
            string mess = "Chuyển thành công số tiền " + dto.price + " từ tài khoản " + dto.accountFrom + " tới tài khoản " + dto.accountTo;
            ViewBag.mess = mess;
            ViewBag.price = currentMoney;
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logon(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Privacy");
            }
            //return Redirect(returnUrl);
        }

        public IActionResult Newspaper()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}