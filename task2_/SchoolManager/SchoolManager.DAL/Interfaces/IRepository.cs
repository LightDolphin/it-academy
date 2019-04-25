using System;
using System.Collections.Generic;

namespace SchoolManager.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
    }
}
