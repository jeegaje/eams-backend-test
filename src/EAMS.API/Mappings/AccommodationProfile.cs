
using AutoMapper;
using EAMS.API.DTOs;
using EAMS.Domain.Entities;

namespace EAMS.API.Mappings
{
    public class AccommodationProfile : Profile
    {
        public AccommodationProfile()
        {
            CreateMap<Accommodation, AccommodationDto>().ReverseMap();
        }
    }
}