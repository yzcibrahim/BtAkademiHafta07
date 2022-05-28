using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordApi.Entities;

namespace WordApi.Dtos
{
    public class WordDefListResult
    {
        public int TotalPageCount { get; set; }
        public IEnumerable<WordDefinition> Liste { get; set; }
    }
}
