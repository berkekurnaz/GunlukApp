using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GunlukApp.DataAccess.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GunlukApp.WebUI.Controllers.Site
{
    public class PanelController : Controller
    {

        DiaryRepository diaryRepository { get; set; }
        ArticlesRepository articlesRepository { get; set; }
        AnnouncementsRepository announcementsRepository { get; set; }

        public PanelController(DiaryRepository diaryRepository, ArticlesRepository articlesRepository, AnnouncementsRepository announcementsRepository)
        {
            this.diaryRepository = diaryRepository;
            this.articlesRepository = articlesRepository;
            this.announcementsRepository = announcementsRepository;
        }

        public IActionResult Index()
        {
            ViewBag.DefterSayisi = diaryRepository.GetAll().Count;
            ViewBag.GunlukSayisi = articlesRepository.GetAll().Count;
            ViewBag.DuyuruSayisi = announcementsRepository.GetAll().Count;

            ViewBag.KullaniciAdi = HttpContext.Session.GetString("SessionNameSurname");

            return View();
        }

        public IActionResult Hata()
        {
            return View();
        }

        public IActionResult NasilKullanilir()
        {
            return View();
        }

    }
}