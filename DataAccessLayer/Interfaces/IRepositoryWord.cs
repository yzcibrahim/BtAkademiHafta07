using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepositoryWord:IRepositoryBase<WordDefinition>
    {
        List<WordDefinition> List(string searchKeyword,int selectedLangId);
    }
}
