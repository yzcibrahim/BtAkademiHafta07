using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepositoryWord
    {
        List<WordDefinition> List();
        WordDefinition GetById(int id);
        void Delete(int id);
        WordDefinition Add(WordDefinition entity);
        WordDefinition Update(WordDefinition entity);
    }
}
