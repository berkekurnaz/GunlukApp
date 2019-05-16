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
            // Burada duyurular listelenecek.
            return View();
        }

        public IActionResult Incele(string id)
        {
            // Burada duyurunun detayları gelecek.
            return View();
        }

    }
}