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
    public class YonetimYoneticilerController : Controller
    {

        SuperUserRepository superUserRepository { get; set; }

        public YonetimYoneticilerController(SuperUserRepository superUserRepository)
        {
            this.superUserRepository = superUserRepository;
        }

        public IActionResult Index()
        {
            var list = superUserRepository.GetAll();
            return View(list);
        }

        public IActionResult Incele(string id)
        {
            var item = superUserRepository.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Hata", "Yonetim");
            }
            return View(item);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(SuperUser superUser)
        {
            if (ModelState.IsValid)
            {
                superUser.CreatedDate = DateTime.Now.ToShortDateString();
                superUser.Photo = "Null";
                superUserRepository.AddModel(superUser);
                return RedirectToAction("Index");
            }
            return View(superUser);
        }

        public IActionResult Guncelle(string id)
        {
            var item = superUserRepository.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Hata", "Yonetim");
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Guncelle(string id, SuperUser newSuperUser)
        {
            var item = superUserRepository.GetById(id);
            if (ModelState.IsValid)
            {
                item.NameSurname = newSuperUser.NameSurname;
                item.Email = newSuperUser.Email;
                item.CreatedDate = newSuperUser.CreatedDate;
                item.Photo = "Null";
                item.Username = newSuperUser.Username;
                item.Password = newSuperUser.Password;

                superUserRepository.UpdateModel(id, item);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Sil(string id, IFormCollection colllection)
        {
            if (ModelState.IsValid)
            {
                superUserRepository.DeleteModel(id);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}