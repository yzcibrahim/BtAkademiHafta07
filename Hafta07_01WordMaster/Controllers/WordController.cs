using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Hafta07_01WordMaster.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hafta07_01WordMaster.Controllers
{
    public class WordController : Controller
    {
        IRepositoryWord _repository;
        public WordController(IRepositoryWord repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {

            return View();
        }
        public PartialViewResult ListPartial(string word)
        {
            List<WordDefinition> liste = _repository.List();

            List<WordDefinitionViewModel> model = new List<WordDefinitionViewModel>();

            foreach (var item in liste)
            {
                WordDefinitionViewModel wd = new WordDefinitionViewModel()
                {
                    Id = item.Id,
                    Meaning = item.Meaning,
                    Word = item.Word
                };

                model.Add(wd);
            }
            return PartialView(model);
        }

        public IActionResult Create(int? id)
        {
            if (id.HasValue && id > 0)
            {
                WordDefinition wordDefinition = _repository.GetById(id.Value);
                WordDefinitionViewModel model = new WordDefinitionViewModel()
                {
                    Id = wordDefinition.Id,
                    Meaning = wordDefinition.Meaning,
                    Word = wordDefinition.Word
                };

                return View(model);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Create(WordDefinitionViewModel model)
        {
            WordDefinition wordDefinition = new WordDefinition()
            {
                Id = model.Id,
                Word = model.Word,
                Meaning = model.Meaning
            };

            if (model.Meaning == model.Word)
            {
                ModelState.AddModelError("Word", "kelime aynı olamazlarrr");
                ModelState.AddModelError("Meaning", "anlam  aynı olamazlarrr");
                ModelState.AddModelError("", "kelimed ve anlam  aynı olamazlarrr");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

           

            #region ilke validations
            //if(String.IsNullOrEmpty(model.Meaning))
            //{
            //    ViewBag.error = "anlam boş olamaz";
            //    return View(model);
            //}
            //if(String.IsNullOrEmpty(model.Word))
            //{
            //    return View(model);
            //}
            #endregion

            if (wordDefinition.Id <= 0)
            {
                _repository.Add(wordDefinition);
            }
            else
            {
                _repository.Update(wordDefinition);
            }
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("index");
        }
    }
}
