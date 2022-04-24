using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using AutoMapper;
using DatingApp.API.DTOs;
using DatingApp.API.Extensions;

namespace DatingApp.API.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberDto>()
          .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src =>
            src.Photos.FirstOrDefault(x => x.IsMain).Url))
          .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
        CreateMap<Photo, PhotoDto>();
    }
  }
}