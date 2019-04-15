using Collab.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collab.Web.Controllers
{
    public class HashtagController : Controller
    {
        private readonly IHashtagService _hashtagService;

        public HashtagController(IHashtagService hashtagService)
        {
            _hashtagService = hashtagService ??
                throw new ArgumentNullException(nameof(hashtagService));
        }
    }
}
