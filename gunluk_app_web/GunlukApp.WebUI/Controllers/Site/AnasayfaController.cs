using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GunlukApp.DataAccess.Concrete;
using GunlukApp.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace GunlukApp.WebUI.Controllers
{
    public class AnasayfaController : Controller
    {

        UserRepository userRepository { get; set; }

        public AnasayfaController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

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

        /* Kayıt Olduktan Sonra Başarılı Sayfası */
        public IActionResult KayitBasarili()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UyeOl(User user)
        {
            var newUser = userRepository.CheckByUsername(user);
            if (newUser == null)
            {
                newUser = userRepository.CheckByMail(user);
                if (newUser == null)
                {
                    user.Photo = "Null";
                    user.CreatedDate = DateTime.Now.ToShortDateString();
                    userRepository.AddModel(user);
                    return RedirectToAction("KayitBasarili");
                }
            }
            ViewBag.UyeOlmaHataMesaji = "Daha Önce Bu Sisteme Bu Kullanıcı Adı Veya Mail Adresi İle Kayıt Olunmuş.Lütfen Farklı Kullanıcı Adı Veya Mail Adresi Giriniz...";
            return View(user);
        }

        /* Anasayfa Giriş Yap Sayfası */
        public IActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GirisYap(User user)
        {
            var newUser = userRepository.Login(user);
            if (newUser != null)
            {
                HttpContext.Session.SetString("SessionUserId", newUser.Id.ToString());
                HttpContext.Session.SetString("SessionUsername", newUser.Username);
                HttpContext.Session.SetString("SessionNameSurname", newUser.NameSurname);
                return RedirectToAction("Index", "Panel");
            }
            ViewBag.GirisYapmaHataMesaji = "Kullanıcı Adını Veya Şifrenizi Yanlış Girdiniz...";
            return View(user);
        }

    }
}