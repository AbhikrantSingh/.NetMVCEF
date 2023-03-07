using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzWalk.Profiles
{
    public class RegionsProfiles : Profile
    {

        public RegionsProfiles()
        {
            CreateMap<Models.Domains.Region, Models.DTO.RegionDTO>().ReverseMap();

            //if name was not same fr DTO and main Class

            // .ForMember(Dest=>dest.id=id_
        }
    }
}
