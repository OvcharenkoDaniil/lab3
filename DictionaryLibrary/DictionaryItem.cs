using System.ComponentModel.DataAnnotations;

namespace DictionaryLibrary
{
    public class DictionaryItem
    {
        [Key]
        public string UserId { get; set; }
        public string UserSurname { get; set; }
        public string PhoneNumber { get; set; }
    }
}