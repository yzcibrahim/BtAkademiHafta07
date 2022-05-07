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

        public static List<WordDefinitionViewModel> DefListToDefViewList(List<WordDefinition> liste)
        {

            List<WordDefinitionViewModel> result = new List<WordDefinitionViewModel>();

            foreach (var item in liste)
            {
                WordDefinitionViewModel wd = new WordDefinitionViewModel()
                {
                    Id = item.Id,
                    Word = item.Word
                };

                foreach (var meaning in item.Meanings)
                {
                    wd.Meanings.Add(new WordMeaningViewModel()
                    {
                        Id = meaning.Id,
                        Meaning = meaning.Meaning,
                        WordDefinitionId = meaning.WordDefinitionId,
                        LangId = meaning.LangId,
                        LangName = meaning.Lang.Name,
                        LangCode = meaning.Lang.Code
                    });

                }

                result.Add(wd);
            }
            return result;
        }
    }
}
