using System;
using SchoolManager.DAL.EF;
using SchoolManager.DAL.Interfaces;
using SchoolManager.DAL.Entities;
using SchoolManager.DAL.Repositories;

namespace SchoolManager.DAL.Repositories
{
    public class EFUoW : IUoW
    {
        private SchoolContext db;
        private PersonRepository personRepository;

        public EFUoW(string connectionString)
        {
            db = new SchoolContext(connectionString);
        }
        public IRepository<Person> Persons
        {
            get
            {
                if (personRepository == null)
                    personRepository = new PersonRepository(db);
                return personRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
