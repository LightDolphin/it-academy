using System.Collections.Generic;
using SchoolManager.BLL.CrossLevelEntities;
using SchoolManager.DAL.Entities;

namespace SchoolManager.BLL.Interfaces
{
    public interface IPersonService
    {
        void Create(PersonCLE person);
        List<PersonCLE> GetPersons();
        void Dispose();
    }
}
