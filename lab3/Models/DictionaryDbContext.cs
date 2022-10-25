using System.Data.Entity;
namespace lab3.Models
{
    
        public class DictionaryDbContext : System.Data.Entity.DbContext
        {
            public DbSet<DictionaryItem> DictionaryItems { get; set; }

            public DictionaryDbContext() : base("DefaultConnection")
            {

            }
        }
    
}