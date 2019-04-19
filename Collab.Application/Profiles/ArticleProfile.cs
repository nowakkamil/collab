using AutoMapper;
using Collab.Data.Entities;
using Collab.Application.Dtos;

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
