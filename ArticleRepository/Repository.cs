using ArticleRepository.Context;
using ArticleRepository.Models;
using ArticleRepository.Validation;
using Microsoft.EntityFrameworkCore;

namespace ArticleRepository
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Guid Create(Article article)
        {
            if (!article.IsValidForCreate())
            {
                throw new ArgumentException("Invalid article data.");
            }

            _context.Articles.Add(article);
            _context.SaveChanges();

            return article.Id;
        }

        public bool Delete(Guid id)
        {
            var article = _context.Articles.FirstOrDefault(x => x.Id == id);

            if (article == null)
            {
                return false;
            }

            _context.Articles.Remove(article);
            var changesCount = _context.SaveChanges(true);

            return changesCount > 0;
        }

        public Article? Get(Guid id)
        {
            return _context.Articles.Find(id);
        }

        public IEnumerable<Article> GetAll()
        {
            return from a in _context.Articles where a.Id != Guid.Empty select a;
        }

        public bool Update(Article articleToUpdate)
        {
            if (!articleToUpdate.IsValidForUpdate() || Get(articleToUpdate.Id) == null)
            {
                return false;
            }


            _context.Update(articleToUpdate);
            var changesCount = _context.SaveChanges();
            
            return changesCount > 0;
        }
    }
}
