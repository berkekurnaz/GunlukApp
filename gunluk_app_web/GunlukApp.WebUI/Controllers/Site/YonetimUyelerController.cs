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
    public class YonetimUyelerController : Controller
    {

        UserRepository userRepository { get; set; }

        public YonetimUyelerController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var list = this.userRepository.GetAll();
            return View(list);
        }

        public IActionResult Incele(string id)
        {
            var item = this.userRepository.GetById(id);
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
        public IActionResult Ekle(User user)
        {
            if (ModelState.IsValid)
            {
                user.Photo = "Null";
                user.CreatedDate = DateTime.Now.ToShortDateString();
                this.userRepository.AddModel(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Sil(string id, IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                this.userRepository.DeleteModel(id);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}