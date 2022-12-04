using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DictionaryLibrary;
using Newtonsoft.Json;

namespace DBRepository
{
    public class DBRepository : IRepository<DictionaryItem>
    {
        private readonly DictionaryDbContext _dbContext;
        private readonly DbSet<DictionaryItem> _records;
        public DBRepository()
        {
            _dbContext = new DictionaryDbContext();
            //_records = _dbContext.Records;
        }
        
        //string filePath2 = "D:\\Study\\Prog-in-internet\\Labs\\lab3\\lab3\\lab3\\Data\\Data.json";
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public List<DictionaryItem> GetDirectoryList()
        {
            return _dbContext.DictionaryItems.ToList();
        }

        public DictionaryItem GetItemById(string id)
        {
            var records = GetDirectoryList();
            return records.FirstOrDefault(r => r.UserId == id);
        }

        public void Add(DictionaryItem item)
        {
            item.UserId = generateID();
            _dbContext.DictionaryItems.Add(item);
            Save();
        }
        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
        public void Update(DictionaryItem item)
        {
            var dictionaryItem =  _dbContext.DictionaryItems.FirstOrDefault(r => r.UserId == item.UserId);
            if (dictionaryItem is null)
            {
                return;
            }
            dictionaryItem.PhoneNumber = item.PhoneNumber;
            dictionaryItem.UserSurname = item.UserSurname;
            Save();
        }

        public void Delete(DictionaryItem item)
        {
            var dictionaryItem = _dbContext.DictionaryItems.FirstOrDefault(r => r.UserId == item.UserId);
            _dbContext.DictionaryItems.Remove(dictionaryItem);
            Save();
        }

        public void Save(List<DictionaryItem> items)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}