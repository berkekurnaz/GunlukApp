using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GunlukApp.WebUI.Controllers
{
    public class AnasayfaController : Controller
    {

        /* Sitenin Anasayfası */
        public IActionResult Index()
        {
            return View();
        }

        /* Anasayfa Nedir Sayfası */
        public IActionResult Nedir()
        {
            return View();
        }

        /* Anasayfa Nasıl Kullanılır Sayfası */
        public IActionResult NasilKullanilir()
        {
            return View();
        }

        /* Anasayfa Takım Sayfası */
        public IActionResult Takim()
        {
            return View();
        }

        /* Anasayfa Iletisim Sayfası */
        public IActionResult Iletisim()
        {
            return View();
        }

        /* Anasayfa Uye Ol Sayfası */
        public IActionResult UyeOl()
        {
            return View();
        }

        /* Anasayfa Giriş Yap Sayfası */
        public IActionResult GirisYap()
        {
            return View();
        }

    }
}