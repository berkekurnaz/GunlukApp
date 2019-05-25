using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GunlukApp.DataAccess.Concrete;
using GunlukApp.Entities.Concrete;
using GunlukApp.WebUI.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ReflectionIT.Mvc.Paging;

namespace GunlukApp.WebUI.Controllers.Site
{
    [UserAuthFilter]
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

        public IActionResult Incele(string id, int sayfa=1)
        {
            
            ViewBag.DiaryId = id;
            var diaryId = new ObjectId(id);
            var item = diaryRepository.GetById(id);
            ViewBag.DiaryName = item.Name;
            var list = articlesRepository.GetAll().FindAll(x => x.DiaryId == diaryId);
            // O defterin içindeki günlükler listelenirken bir kontrol yap.
            var model = PagingList.Create(list, 10, sayfa);
            return View(model);
        }

        /* En Fazla 6 Defter Ekleyebilir */
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Diary diary)
        {
            if (ModelState.IsValid)
            {
                var userId = new ObjectId(HttpContext.Session.GetString("SessionUserId").ToString());
                if (diaryRepository.GetAll().FindAll(x => x.UserId == userId).Count < 6)
                {
                    diary.UserId = new ObjectId(HttpContext.Session.GetString("SessionUserId").ToString());
                    diary.CreatedDate = DateTime.Now.ToShortDateString();
                    diaryRepository.AddModel(diary);
                    TempData["DefterEklemeMesaji"] = "Yeni Bir Defter Başarıyla Eklendi.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["DefterSayiHataMesaji"] = "En Fazla 6 Adet Defter Ekleyebilirsin.";
                    return RedirectToAction("Index");
                }        
            }
            return View(diary);
        }

        public IActionResult Guncelle(string id)
        {
            var userId = new ObjectId(HttpContext.Session.GetString("SessionUserId").ToString());
            var item = diaryRepository.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Hata", "Panel");
            }
            if (item.UserId != userId)
            {
                return RedirectToAction("Hata", "Panel"); // Kullanıcı Kontrolü
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Guncelle(string id, Diary diary)
        {
            var item = diaryRepository.GetById(id);
            if(ModelState.IsValid)
            {
                item.Name = diary.Name;
                item.Description = diary.Description;
                diaryRepository.UpdateModel(id, item);
                TempData["DefterGuncellemeMesaji"] = "Defter Başarıyla Güncellendi.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Sil(string id)
        {
            var userId = new ObjectId(HttpContext.Session.GetString("SessionUserId").ToString());
            var item = diaryRepository.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Hata", "Panel");
            }
            if (item.UserId != userId)
            {
                return RedirectToAction("Hata", "Panel"); // Kullanıcı Kontrolü
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Sil(string id, IFormCollection collection)
        {
            if(ModelState.IsValid)
            {
                List<Articles> list = articlesRepository.GetAll().FindAll(x => x.DiaryId == new ObjectId(id));
                for (int i = 0; i < list.Count; i++)
                {
                    var item = new ObjectId(list[i].Id.ToString());
                    articlesRepository.DeleteModel(item.ToString());
                }
                diaryRepository.DeleteModel(id);
                TempData["DefterSilmeMesaji"] = "Defter Ve İçerisindeki Günlükler Başarıyla Silindi.";
                return RedirectToAction("Index");
            }
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
                article.CreatedYear = DateTime.Now.Year;
                article.CreatedMonth = DateTime.Now.Month;
                article.CreatedDay = DateTime.Now.Day;
                articlesRepository.AddModel(article);
                TempData["GunlukEkleMesaji"] = "Yeni Günlük Başarıyla Eklendi.";
                return RedirectToAction("Incele", new { Id = article.DiaryId });
            }
            return View();
        }

        public IActionResult GunlukOku(string id)
        {
            var userId = new ObjectId(HttpContext.Session.GetString("SessionUserId").ToString());
            var item = articlesRepository.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Hata", "Panel");
            }
            if (item.UserId != userId)
            {
                return RedirectToAction("Hata", "Panel"); // Kullanıcı Kontrolü
            }
            return View(item);
        }

        public IActionResult GunlukDuzenle(string id)
        {
            var userId = new ObjectId(HttpContext.Session.GetString("SessionUserId").ToString());
            var item = articlesRepository.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Hata", "Panel");
            }
            if (item.UserId != userId)
            {
                return RedirectToAction("Hata", "Panel"); // Kullanıcı Kontrolü
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult GunlukDuzenle(string id, Articles article)
        {
            var item = articlesRepository.GetById(id);
            if (ModelState.IsValid)
            {
                item.Title = article.Title;
                item.Content = article.Content;
                item.CreatedDate = article.CreatedDate;
                articlesRepository.UpdateModel(id, item);
                TempData["GunlukDuzenleMesaji"] = "Günlük Başarıyla Güncellendi.";
                return RedirectToAction("Incele", new { Id = item.DiaryId });
            }
            return View(article);
        }

        public IActionResult GunlukSil(string id)
        {
            var userId = new ObjectId(HttpContext.Session.GetString("SessionUserId").ToString());
            var item = articlesRepository.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Hata", "Panel");
            }
            if (item.UserId != userId)
            {
                return RedirectToAction("Hata", "Panel"); // Kullanıcı Kontrolü
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult GunlukSil(string id, IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                articlesRepository.DeleteModel(id);
                TempData["GunlukSilMesaji"] = "Günlük Başarıyla Silindi.";
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}