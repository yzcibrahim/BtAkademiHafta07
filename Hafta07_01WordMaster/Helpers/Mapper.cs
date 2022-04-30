using DataAccessLayer.Entities;
using Hafta07_01WordMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hafta07_01WordMaster.Helpers
{
    public static class Mapper
    {
        public static List<LanguageViewModel> LangListToLangViewModelList(List<Language> liste)
        {
            
            List<LanguageViewModel> result = new List<LanguageViewModel>();

            foreach (var lang in liste)
            {
                LanguageViewModel lwm = new LanguageViewModel()
                {
                    Id = lang.Id,
                    Code = lang.Code,
                    Name = lang.Name
                };
                result.Add(lwm);
            }

            return result;
        }

        public static List<WordDefinitionViewModel> DefListToDefViewList(List<WordDefinition>liste)
        {

            List<WordDefinitionViewModel> result = new List<WordDefinitionViewModel>();

            foreach (var item in liste)
            {
                WordDefinitionViewModel wd = new WordDefinitionViewModel()
                {
                    Id = item.Id,
                    Meaning = item.Meaning,
                    Word = item.Word
                };

                result.Add(wd);
            }
            return result;
        }
    }
}
