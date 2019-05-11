using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GunlukApp.DataAccess.Concrete;
using GunlukApp.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GunlukApp.WebUI.Controllers.Site
{
    public class YonetimController : Controller
    {

        SuperUserRepository superUserRepository { get; set; }

        public YonetimController(SuperUserRepository superUserRepository)
        {
            this.superUserRepository = superUserRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hata()
        {
            return View();
        }

        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Giris(SuperUser superUser)
        {
            var newSuperUser = superUserRepository.Login(superUser);
            if (newSuperUser != null)
            {
                HttpContext.Session.SetString("SessionSuperUsername", superUser.Username);
                return RedirectToAction("Index", "Yonetim");
            }
            return View(superUser);
        }

        public IActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Anasayfa");
        }

    }
}