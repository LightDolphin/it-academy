using SchoolManager.DAL.Entities;
using System;

namespace SchoolManager.DAL.Interfaces
{
    public interface IUoW : IDisposable
    {
        IRepository<Person> Persons { get; }
        void Save();
    }
}
