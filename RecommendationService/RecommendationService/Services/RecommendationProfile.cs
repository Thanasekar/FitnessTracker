using AutoMapper;
using RecommendationService.Entities;
using RecommendationService.Models;

namespace RecommendationService.Services
{
    public class RecommendationProfile : Profile
    {
        public RecommendationProfile()
        {
            CreateMap<RecommendationCreateDto, RecommentationDetail>();
            CreateMap<RecommentationDetail, RecommendationResponseDto>();
        }
        
    }
}
