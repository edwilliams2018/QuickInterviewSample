using System.ComponentModel.DataAnnotations;

namespace ArticleRepository.Models
{
    public class Article
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Text { get; set; }
    }
}
