using System;
using System.Collections.Generic;

namespace DictionaryLibrary
{
    public interface IRepository<T> : IDisposable 
        where T : class
    {
        List<DictionaryItem> GetDirectoryList();
        T GetItemById(string id); 
        void Add(T item); 
        void Update(T item);
        void Delete(T item); 
        void Save(List<T> items);
        void Save();
    }
}