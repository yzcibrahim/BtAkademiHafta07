using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class WordDefinition
    {
        public int Id { get; set; }
        public string Word { get; set; }

        public List<WordMeaning> Meanings { get; set; }
    }

   
}
