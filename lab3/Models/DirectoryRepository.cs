using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace lab3.Models
{
    public class DirectoryRepository : IRepository<DictionaryItem>
    {
        string filePath2 = "D:\\Study\\Prog-in-internet\\Labs\\lab3\\lab3\\lab3\\Data\\Data.json";
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public List<DictionaryItem> GetDirectoryList()
        {
            return JsonConvert.DeserializeObject<List<DictionaryItem>>(System.IO.File.ReadAllText(filePath2));
        }

        public DictionaryItem GetItemById(string id)
        {
            var records = GetDirectoryList();
            return records.FirstOrDefault(r => r.UserId == id);
        }

        public void Add(DictionaryItem item)
        {
            var records = GetDirectoryList();
            item.UserId = generateID();
            records.Add(item);
            Save(records);
        }
        public string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
        public void Update(DictionaryItem item)
        {
            var records = GetDirectoryList();
            var dictionaryItem =  records.FirstOrDefault(r => r.UserId == item.UserId);
            if (dictionaryItem is null)
            {
                return;
            }
            dictionaryItem.PhoneNumber = item.PhoneNumber;
            dictionaryItem.UserSurname = item.UserSurname;
            Save(records);
        }

        public void Delete(DictionaryItem item)
        {
            var records = GetDirectoryList();
            records =  records.Where(r => r.UserId != item.UserId).ToList();
            Save(records);
        }

        public void Save(List<DictionaryItem> items)
        {
            if (System.IO.File.Exists(filePath2))
            {
                System.IO.File.WriteAllText(filePath2,JsonConvert.SerializeObject(items));
            }
        }
    }
}