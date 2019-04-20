# Contribution Guidelines

This document focuses on coding conventions which each collaborator has to follow.

###### Based on the following example certain rules will be discussed

```c#
using AutoMapper;
using Collab.Application.Dtos;
using Collab.Application.Services.Interfaces;
using Collab.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
```

## Analysis

1. File is **formatted** using built-in functionality (<kbd>Ctrl</kbd> + <kbd>K</kbd> + <kbd>D</kbd> in Visual Studio 2017).
2. **Using** statements are **organized** (<kbd>Ctrl</kbd> + <kbd>R</kbd> + <kbd>G</kbd> in Visual Studio 2017).
3. There are **no two consecutive blank lines** and there isn't any void space after an opening brace and before the closing one.
4. **Blank lines are introduced only for the sake of brevity**. They are placed inside a method and a single one suggests that a different operation will be taking place. Furthermore, a statement with AutoMapper doesn't require surrounding void space since it only reduces boilerplate code.
5. Methods are arranged in **CRUD order**. Moreover, within the given operation, they are filed in terms of their specificity - first with one parameter, second with two, etc. (*except for the last one which is parameterless*).
6. The line length should, ideally, be less than **80 characters** (circa 100 characters is acceptable). If necessary, line break should be introduced.
7. Absence of **trailing whitespaces** (display all whitespace characters with this combination: <kbd>Ctrl</kbd> + <kbd>R</kbd> + <kbd>W</kbd> in Visual Studio 2017).
