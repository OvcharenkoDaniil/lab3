using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Newtonsoft.Json;
using System.IO;
using DictionaryLibrary;
using DictionaryRepository;

namespace lab3.Controllers
{
    public class DictionaryController : Controller
    {
        private List<DictionaryItem> dictionaryItems = new List<DictionaryItem>();
        //private DictionaryRepository.DictionaryRepository _directoryRepository = new DictionaryRepository.DictionaryRepository();
        private DBRepository.DBRepository _directoryRepository = new DBRepository.DBRepository();
        [HttpGet]
        public ActionResult Index()
        {
            dictionaryItems = _directoryRepository.GetDirectoryList();
            var sortedRecords = dictionaryItems.OrderBy(r => r.UserSurname).ToList();
            return View(sortedRecords);
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            var record = _directoryRepository.GetItemById(id);
            return View(record);
        }

        [HttpPost]
        public ActionResult UpdateSave(DictionaryItem record)
        {
            _directoryRepository.Update(record);
            return Redirect("/Dictionary/Index");
        }
        
        [HttpPost]
        public ActionResult DeleteSave(DictionaryItem record)
        {
            _directoryRepository.Delete(record);
            return Redirect("/Dictionary/Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var record = _directoryRepository.GetItemById(id);
            return View(record);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new DictionaryItem());
        }
        
        [HttpPost]
        public ActionResult AddSave(DictionaryItem record)
        {
            _directoryRepository.Add(record);
            return Redirect("/Dictionary/Index");
        }
        
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public string WrongPath()
        {
            return $"{Request.HttpMethod}: " + $"{Request.Url.AbsoluteUri} не поддерживается";
        }
    }
}