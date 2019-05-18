using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GunlukApp.DataAccess.Concrete;
using GunlukApp.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace GunlukApp.WebUI.Controllers.Site
{
    public class PanelProfilController : Controller
    {

        UserRepository userRepository { get; set; }

        public PanelProfilController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            //var userId = new ObjectId(HttpContext.Session.GetString("SessionUserId").ToString());
            var userId = HttpContext.Session.GetString("SessionUserId");
            var item = userRepository.GetById(userId);
            return View(item);
        }

        public IActionResult Duzenle(string id)
        {
            var item = userRepository.GetById(id);
            // Burada Kullanıcı Id Kendi Id simi diye kontrol edilecek.
            if (item == null)
            {
                return RedirectToAction("Hata", "Panel");
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Duzenle(string id, User user)
        {
            var item = userRepository.GetById(id);
            if (ModelState.IsValid)
            {
                item.Username = user.Username;
                item.NameSurname = user.NameSurname;
                item.Email = user.Email;
                userRepository.UpdateModel(id, item);
                TempData["ProfilDuzenlemeMesaji"] = "Profil Bilgilerin Başarıyla Güncellendi.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Sifre(string id)
        {
            var item = userRepository.GetById(id);
            // Burada Kullanıcı Id Kendi Id simi diye kontrol edilecek.
            if (item == null)
            {
                return RedirectToAction("Hata", "Panel");
            }
            return View(item);
        }

        
        [HttpPost]
        public IActionResult Sifre(string id, string oldPassword, string newPassword)
        {
            var item = userRepository.GetById(id);
            if (ModelState.IsValid)
            {
                if (item.Password == oldPassword)
                {
                    item.Password = newPassword;
                    userRepository.UpdateModel(id, item);
                    TempData["SifreDuzenlemeMesaji"] = "Şifren Başarıyla Güncellendi.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["SifreDuzenlemeHataMesaji"] = "Lütfen Önceki Şifrenizi Doğru Giriniz.";
                }
            }
            return View();
        }

        /* Fotograf Duzenleme Islemi Yapilacak */
        public IActionResult Fotograf(string id)
        {
            var item = userRepository.GetById(id);
            // Burada Kullanıcı Id Kendi Id simi diye kontrol edilecek.
            if (item == null)
            {
                return RedirectToAction("Hata", "Panel");
            }
            return View(item);
        }
        
        [HttpPost]
        public async Task<IActionResult> Fotograf(string id, User user, IFormFile Image)
        {
            var item = userRepository.GetById(id);
            if (Image != null)
            {
                if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "\\wwwroot\\UserPhotos\\" + item.Photo))
                {
                    System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\wwwroot\\UserPhotos\\" + item.Photo);
                }
                string newImage = Guid.NewGuid().ToString() + Image.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\UserPhotos", newImage);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                item.Photo = newImage;
            }
            userRepository.UpdateModel(id, item);
            TempData["FotografDuzenlemeMesaji"] = "Profil Fotoğrafın Başarıyla Güncellendi.";
            return RedirectToAction("Index");
        }

    }
}