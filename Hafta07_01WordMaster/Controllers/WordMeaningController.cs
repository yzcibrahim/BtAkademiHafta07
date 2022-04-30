using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Hafta07_01WordMaster.Helpers;
using Hafta07_01WordMaster.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hafta07_01WordMaster.Controllers
{
    public class WordMeaningController : Controller
    {
        IRepositoryMeaning _repository;
        IRepositoryLanguage _repositoryLanguage;
        IRepositoryWord _repositoryWord;
        public WordMeaningController(IRepositoryMeaning repository,IRepositoryLanguage repositoryLanguage, IRepositoryWord repositoryWord)
        {
            _repository = repository;
            _repositoryLanguage = repositoryLanguage;
            _repositoryWord = repositoryWord;
        }
        public ActionResult Index()
        {
            List<WordMeaning> liste = _repository.List();
            List<WordMeaningViewModel> listeModel = new List<WordMeaningViewModel>();

            foreach (var item in liste)
            {
                WordMeaningViewModel mvm = new WordMeaningViewModel()
                {
                    Id = item.Id,
                    LangId = item.LangId,
                    Meaning = item.Meaning,
                    WordDefinitionId = item.WordDefinitionId,
                    WordDef = item.WordDef.Word,
                    LangCode = item.Lang.Code,
                    LangName = item.Lang.Name
                };
                listeModel.Add(mvm);
            }

            return View(listeModel);
        }



        // GET: WordMeaningController/Create
        public ActionResult Create(int? id)
        {
            WordMeaningViewModel model = new WordMeaningViewModel();
            if (id.HasValue && id > 0)
            {
                var entity = _repository.GetById(id.Value);
                model.Id = entity.Id;
                model.LangId = entity.LangId;
                model.WordDefinitionId = entity.WordDefinitionId;
                model.Meaning = entity.Meaning;
            }
            var langList = _repositoryLanguage.List();
            model.Langs = Mapper.LangListToLangViewModelList(langList);

            var defList = _repositoryWord.List();
            ViewBag.defs = Mapper.DefListToDefViewList(defList);

            return View(model);
        }

        // POST: WordMeaningController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WordMeaningViewModel model)
        {
            var entity = new WordMeaning() { Id = model.Id, LangId = model.LangId, WordDefinitionId = model.WordDefinitionId, Meaning = model.Meaning };
            if (model.Id > 0)
            {
                _repository.Update(entity);
            }
            else
            {
                _repository.Add(entity);
            }
            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("index");
        }


    }
}
