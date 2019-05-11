using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GunlukApp.DataAccess.Concrete;
using GunlukApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace GunlukApp.WebUI.Controllers.Site
{
    public class YonetimYoneticilerController : Controller
    {

        SuperUserRepository superUserRepository { get; set; }

        public YonetimYoneticilerController(SuperUserRepository superUserRepository)
        {
            this.superUserRepository = superUserRepository;
        }

        public IActionResult Index()
        {
            // Listele
            return View();
        }

        public IActionResult Incele()
        {
            // Incele
            return View();
        }

        public IActionResult Ekle()
        {
            // Ekle
            return View();
        }

        public IActionResult Guncelle()
        {
            // Guncelle
            return View();
        }

        public IActionResult Sil()
        {
            // Sil
            return View();
        }

    }
}