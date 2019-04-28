using AutoMapper;
using Collab.Application.Dtos;
using Collab.Application.Services.Interfaces;
using Collab.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Collab.Web.Controllers
{
    [Route("api/[controller]")]
    public class HashtagController : Controller
    {
        private readonly IHashtagService _hashtagService;
        private readonly IMapper _mapper;

        public HashtagController(
            IHashtagService hashtagService,
            IMapper mapper)
        {
            _hashtagService = hashtagService ??
                throw new ArgumentNullException(nameof(hashtagService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost]
        public async Task<IActionResult> CreateHashtag([FromBody]HashtagDto hashtagDto)
        {
            var hashtag = _mapper.Map<Hashtag>(hashtagDto);
            hashtag = await _hashtagService.CreateHashtagAsync(hashtag);

            if (hashtag == null)
            {
                return BadRequest();
            }

            hashtagDto = _mapper.Map<HashtagDto>(hashtag);
            return Ok(hashtagDto);
        }

        [HttpPut("{hashtagName}/{articleId}")]
        public async Task<IActionResult> AddArticleToHashtag(int articleId, string hashtagName)
        {
            var result = await _hashtagService.AddArticleToHashtagAsync(articleId, hashtagName);

            if (result != null)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHashtagById(int id)
        {
            var hashtag = await _hashtagService.GetHashtagByIdAsync(id);

            if (hashtag == null)
            {
                return NotFound();
            }

            var hashtagDto = _mapper.Map<HashtagDto>(hashtag);
            return Ok(hashtagDto);
        }

        [HttpGet("{name:string}")]
        public async Task<IActionResult> GetHashtagByName(string name)
        {
            var hashtag = await _hashtagService.GetHashtagByNameAsync(name);

            if (hashtag == null)
            {
                return NotFound();
            }

            var hashtagDto = _mapper.Map<HashtagDto>(hashtag);
            return Ok(hashtagDto);
        }

        [HttpGet("articles/{hashtagName}")]
        public async Task<IActionResult> GetArticlesByHashtagName(string hashtagName)
        {
            var articles = await _hashtagService.GetArticlesByHashtagName(hashtagName);

            if (articles == null)
            {
                return NotFound();
            }

            return Ok(articles);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteHashtagById(int id)
        {
            var result = await _hashtagService.DeleteHashtagByIdAsync(id);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{name:string}")]
        public async Task<IActionResult> DeleteHashtagByName(string name)
        {
            var result = await _hashtagService.DeleteHashtagByNameAsync(name);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
