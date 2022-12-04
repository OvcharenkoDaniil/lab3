using System.Data.Entity;
using DictionaryLibrary;

namespace DBRepository
{
    
        public class DictionaryDbContext : System.Data.Entity.DbContext
        {
            public DbSet<DictionaryItem> DictionaryItems { get; set; }

            public DictionaryDbContext() : base("DefaultConnection")
            {

            }
        }
    
}