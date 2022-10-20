using System.ComponentModel.DataAnnotations;

namespace lab3.Models
{
    public class DictionaryItem
    {
        [Key]
        public string UserId { get; set; }
        public string UserSurname { get; set; }
        public string PhoneNumber { get; set; }
    }
}