using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordApi.Entities
{
    public class WordDefinition
    {
        public int Id { get; set; }
        public string Word { get; set; }

        public int? LanguageId { get; set; }

        public List<WordMeaning> Meanings { get; set; }
    }
}
