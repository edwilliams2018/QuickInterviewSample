using ArticleRepository.Models;

namespace ArticleRepository.Validation
{
    public static class ArticleValidation
    {
        public static bool IsValidForCreate(this Article article )
        {
            return
                article != null &&
                !string.IsNullOrWhiteSpace(article.Title)
                ;
        }

        public static bool IsValidForUpdate(this Article article)
        {
            return
                IsValidForCreate(article) &&
                article.Id != Guid.Empty
            ;
        }
    }
}
