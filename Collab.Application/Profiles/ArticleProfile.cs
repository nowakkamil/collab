using AutoMapper;
using Collab.Application.Dtos;
using Collab.Data.Entities;

namespace Collab.Application.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDto>()
                .ForMember(
                    dest => dest.ApplicationUserID,
                    opt => opt.MapFrom(src => src.ApplicationUser.Id)
                );

            CreateMap<ArticleDto, Article>()
                .ForPath(
                    dest => dest.ApplicationUser.Id,
                    opt => opt.MapFrom(src => src.ApplicationUserID)
                );
        }
    }
}
