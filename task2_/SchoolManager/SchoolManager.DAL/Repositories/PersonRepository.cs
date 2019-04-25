using System;
using System.Collections.Generic;
using System.Linq;
using SchoolManager.DAL.Entities;
using SchoolManager.DAL.Interfaces;
using SchoolManager.DAL.EF;

namespace SchoolManager.DAL.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private SchoolContext db;

        public PersonRepository(SchoolContext context)
        {
            this.db = context;
        }

        public IEnumerable<Person> GetAll()
        {
            return db.Persons;
        }

        public void Create(Person person)
        {
            db.Persons.Add(person);
        }

        public IEnumerable<Person> Find(Func<Person, Boolean> predicate)
        {
            return db.Persons.Where(predicate).ToList();
        }
    }
}
