using SchoolManager.BLL.CrossLevelEntities;
using SchoolManager.DAL.Entities;
using SchoolManager.DAL.Interfaces;
using SchoolManager.BLL.Interfaces;
using System.Collections.Generic;
using AutoMapper;

namespace SchoolManager.BLL.Services
{
    public class PersonService : IPersonService
    {
        IUoW Database { get; set; }

        public PersonService(IUoW iuow)
        {
            Database = iuow;
        }
        public List<PersonCLE> GetPersons()
        {
            List<PersonCLE> pCLE = new List<PersonCLE>();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Person, PersonCLE>()).CreateMapper();
            foreach (Person p in Database.Persons.GetAll())
            {
                pCLE.Add(mapper.Map<Person, PersonCLE>(p));
            }
            return pCLE;
        }

        public void Create(PersonCLE person)
        { 
            if (person == null)
            {
                throw new System.Exception("Добавляемый человек не может быть пустым");
            }
            else
            {
                if (person.FirstName == null || person.LastName == null || person.MiddleName == null || person.Telephone == null || person.BirthDay == null || person.Email == null)
                {
                    throw new System.Exception("Одно из переданных на сервер полей было пустым. Проверьте значения");
                }
                else
                {
                    string s = person.Telephone;
                    if (s.Length < 3)
                    {
                        throw new System.Exception("Некорректный номер телефона");
                    }
                    else
                    {
                        s = s.Substring(0, 2);
                        if (s != "29" && s != "33" && s != "25") throw new System.Exception("На сервер передан некорректный номер " + person.Telephone);
                    }
                }
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PersonCLE, Person>()).CreateMapper();
            Database.Persons.Create(mapper.Map<PersonCLE, Person>(person));
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
