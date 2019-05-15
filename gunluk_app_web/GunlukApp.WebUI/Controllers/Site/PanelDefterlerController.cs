using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GunlukApp.DataAccess.Concrete;
using GunlukApp.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace GunlukApp.WebUI.Controllers.Site
{
    public class PanelDefterlerController : Controller
    {

        DiaryRepository diaryRepository { get; set; }
        ArticlesRepository articlesRepository { get; set; }

        public PanelDefterlerController(DiaryRepository diaryRepository, ArticlesRepository articlesRepository)
        {
            this.diaryRepository = diaryRepository;
            this.articlesRepository = articlesRepository;
        }

        public IActionResult Index()
        {
            var userId = new ObjectId(HttpContext.Session.GetString("SessionUserId").ToString());
            var list = diaryRepository.GetAll().FindAll(x => x.UserId == userId);
            return View(list);
        }

        /* Burada O Gunluge Ait Butun Gunlukler Listelenecek */
        public IActionResult Incele(string id)
        {
            ViewBag.DiaryId = id;
            var diaryId = new ObjectId(id);
            var list = articlesRepository.GetAll().FindAll(x => x.DiaryId == diaryId);
            return View(list);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Diary diary)
        {
            if (ModelState.IsValid)
            {
                diary.UserId = new ObjectId(HttpContext.Session.GetString("SessionUserId").ToString());
                diary.CreatedDate = DateTime.Now.ToShortDateString();
                diaryRepository.AddModel(diary);
                return RedirectToAction("Index");
            }
            return View(diary);
        }

        public IActionResult Guncelle()
        {
            return View();
        }

        public IActionResult Sil()
        {
            return View();
        }

        public IActionResult GunlukEkle(string id)
        {
            var diaryId = new ObjectId(id);
            return View();
        }

        [HttpPost]
        public IActionResult GunlukEkle(string id, Articles article)
        {
            var diaryId = new ObjectId(id);
            if (ModelState.IsValid)
            {
                article.DiaryId = diaryId;
                article.UserId = new ObjectId(HttpContext.Session.GetString("SessionUserId").ToString());
                article.CreatedDate = DateTime.Now.ToShortDateString();
                article.CreatedYear = DateTime.Now.Year;
                article.CreatedMonth = DateTime.Now.Month;
                article.CreatedDay = DateTime.Now.Day;
                articlesRepository.AddModel(article);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}