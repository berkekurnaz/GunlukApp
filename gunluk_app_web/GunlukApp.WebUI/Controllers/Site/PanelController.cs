using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GunlukApp.DataAccess.Concrete;
using GunlukApp.WebUI.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace GunlukApp.WebUI.Controllers.Site
{
    [UserAuthFilter]
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
            var userId = new ObjectId(HttpContext.Session.GetString("SessionUserId").ToString());

            ViewBag.DefterSayisi = diaryRepository.GetAll().FindAll(x => x.UserId == userId).Count;
            ViewBag.GunlukSayisi = articlesRepository.GetAll().FindAll(x => x.UserId == userId).Count;
            ViewBag.DuyuruSayisi = announcementsRepository.GetAll().Count;

            ViewBag.KullaniciIsmi = HttpContext.Session.GetString("SessionUserNameSurname");

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