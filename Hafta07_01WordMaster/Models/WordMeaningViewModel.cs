using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hafta07_01WordMaster.Models
{
    public class WordMeaningViewModel
    {
        public int Id { get; set; }
        public string Meaning { get; set; }
        public int? LangId { get; set; }
        public int? WordDefinitionId { get; set; }

        public string LangCode { get; set; }
        public string WordDef { get; set; }

        public string LangName { get; set; }

        public List<LanguageViewModel> Langs { get; set; }

        

    }
}
