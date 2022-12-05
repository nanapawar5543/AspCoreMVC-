using System.ComponentModel.DataAnnotations;

namespace BookStore.Model
{
    public class LanguageModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
