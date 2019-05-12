using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GunlukApp.DataAccess.Concrete;
using GunlukApp.Entities.Concrete;
using GunlukApp.WebUI.Filter;
using Microsoft.AspNetCore.Mvc;

namespace GunlukApp.WebUI.Controllers.Site
{
    [SuperUserAuthFilter]
    public class YonetimDuyurularController : Controller
    {

        AnnouncementsRepository announcementsRepository { get; set; }

        public YonetimDuyurularController(AnnouncementsRepository announcementsRepository)
        {
            this.announcementsRepository = announcementsRepository;
        }

        public IActionResult Index()
        {
            var list = announcementsRepository.GetAll();
            return View(list);
        }

        public IActionResult Incele(string id)
        {
            var item = announcementsRepository.GetById(id);
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
        public IActionResult Ekle(Announcements announcement)
        {
            if(ModelState.IsValid)
            {
                announcementsRepository.AddModel(announcement);
                return RedirectToAction("Index");
            }
            return View(announcement);
        }

        public IActionResult Guncelle(string id)
        {
            var item = announcementsRepository.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Hata", "Yonetim");
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Guncelle(string id, Announcements newAnouncements)
        {
            var item = announcementsRepository.GetById(id);
            if (ModelState.IsValid)
            {
                item.Title = newAnouncements.Title;
                item.CreatedDate = newAnouncements.CreatedDate;
                item.Content = newAnouncements.Content;

                announcementsRepository.UpdateModel(id, item);
                return RedirectToAction("Index");
            }
            return View();
        }
           
        [HttpPost]
        public IActionResult Sil(string id)
        {
            if (ModelState.IsValid)
            {
                announcementsRepository.DeleteModel(id);
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}