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
    public class LanguageController : Controller
    {
        IRepositoryLanguage _repository;
        public LanguageController(IRepositoryLanguage repository)
        {
            _repository = repository;
        }
        // GET: LanguageController
        public ActionResult Index()
        {
            List<Language> liste = _repository.List();
            List<LanguageViewModel> model = Mapper.LangListToLangViewModelList(liste);

            return View(model);
        }

        // GET: LanguageController/Create
        public ActionResult Create(int? id)
        {
            LanguageViewModel model = new LanguageViewModel();

            if (id.HasValue && id > 0)
            {
                Language lng = _repository.GetById(id.Value);

                model.Id = lng.Id;
                model.Code = lng.Code;
                model.Name = lng.Name;

            }

            return View(model);
        }

        // POST: LanguageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LanguageViewModel model)
        {
            Language entity = new Language()
            {
                Id = model.Id,
                Name = model.Name,
                Code = model.Code
            };
            if(entity.Id>0)
            {
                _repository.Update(entity);
            }
            else
            {
                _repository.Add(entity);
            }
            return RedirectToAction("Index");
        }

        // GET: LanguageController/Delete/5
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}
