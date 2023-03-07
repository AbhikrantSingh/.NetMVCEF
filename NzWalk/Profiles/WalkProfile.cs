using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzWalk.Profiles
{
    public class WalkProfile : Profile
    {
        public WalkProfile()
        {
            CreateMap<Models.Domains.Walk, Models.DTO.WalkDTO>().ReverseMap();
            CreateMap<Models.Domains.WalkDifficulty, Models.DTO.WalkDifficultyDTO>().ReverseMap();
        }
    }
}
