using System;
using System.Threading.Tasks;
using AutoMapper;
using Collab.Application.Services;
using Collab.Data.Entities;
using Collab.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Collab.Web.Controllers
{
    [Route("api/[controller]")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IApplicationUserService _applicationUserService;
        private readonly IMapper _mapper;

        public ArticleController(
            IArticleService articleService,
            IApplicationUserService applicationUserService,
            IMapper mapper)
        {
            _articleService = articleService ??
                throw new ArgumentNullException(nameof(articleService));
            _applicationUserService = applicationUserService ??
                throw new ArgumentNullException(nameof(applicationUserService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle([FromBody]ArticleDto articleDto)
        {
            var user = await _applicationUserService
                .GetApplicationUserByIdAsync(articleDto.ApplicationUserID);

            if (user == null)
            {
                return BadRequest();
            }

            var article = _mapper.Map<Article>(articleDto);
            article = await _articleService.CreateArticleAsync(article);

            if (article == null)
            {
                return BadRequest();
            }

            articleDto = _mapper.Map<ArticleDto>(article);
            return Ok(articleDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticleById(int id)
        {
            var article = await _articleService.GetArticleByIdAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            var articleDto = _mapper.Map<ArticleDto>(article);
            return Ok(articleDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArticles()
        {
            var articles = await _articleService.GetAllArticlesAsync();

            if (articles == null || articles.Count == 0)
            {
                return NotFound();
            }

            var articleDto = _mapper.Map<List<ArticleDto>>(articles);
            return Ok(articleDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle(int id, [FromBody]ArticleDto articleDto)
        {
            var article = await _articleService
                .UpdateArticleAsync(_mapper.Map<Article>(articleDto));

            if (article == null)
            {
                return BadRequest();
            }

            articleDto = _mapper.Map<ArticleDto>(article);
            return Ok(articleDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticleById(int id)
        {
            var result = await _articleService.DeleteArticleByIdAsync(id);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
