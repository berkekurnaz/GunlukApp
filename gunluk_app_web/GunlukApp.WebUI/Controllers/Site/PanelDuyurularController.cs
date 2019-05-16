using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GunlukApp.DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace GunlukApp.WebUI.Controllers.Site
{
    public class PanelDuyurularController : Controller
    {

        AnnouncementsRepository announcementsRepository { get; set; }

        public PanelDuyurularController(AnnouncementsRepository announcementsRepository)
        {
            this.announcementsRepository = announcementsRepository;
        }

        public IActionResult Index()
        {
            var list = announcementsRepository.GetAll().OrderByDescending(x => x.Id);
            return View(list);
        }

        public IActionResult Incele(string id)
        {
            var item = announcementsRepository.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Hata", "Panel");
            }
            return View(item);
        }

    }
}