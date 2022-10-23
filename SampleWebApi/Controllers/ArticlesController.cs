using ArticleRepository;
using ArticleRepository.Models;
using ArticleRepository.Validation;
using Microsoft.AspNetCore.Mvc;

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private IRepository _repository;
        const string ArticleNotFound = "Article not found.";

        public ArticlesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var results = _repository.GetAll().ToArray();
            return Ok(results);
        }

        [HttpGet("{articleId}")]
        public IActionResult Get(Guid articleId)
        {
            var article = _repository.Get(articleId);

            return article != null ? Ok(article) : NotFound(ArticleNotFound);
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            if (!article.IsValidForCreate())
            {
                return BadRequest();
            }
            
            var newArticle = _repository.Get(_repository.Create(article));

            return Ok(newArticle);
        }

        [HttpDelete("{articleId}")]
        public IActionResult Delete(Guid articleId)
        {
            return _repository.Delete(articleId)
                ? Ok()
                : NotFound(ArticleNotFound);
        }

        [HttpPut]
        public IActionResult Update(Article article)
        {
            // Using the validators here because the repository interface defined returned bool, so we have no way
            // to determine if the false was due to invalid structure or non-existent record.
            if (!article.IsValidForUpdate())
            {
                return BadRequest("");
            }

            return _repository.Update(article)
                ? Ok()
                : NotFound(ArticleNotFound)
            ;
        }
    }
}
