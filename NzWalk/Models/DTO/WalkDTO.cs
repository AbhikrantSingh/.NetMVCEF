using NzWalk.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzWalk.Models.DTO
{
    public class WalkDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDiffcultyId { get; set; }

        //Nav Prop
        public RegionDTO Region { get; set; }
        public WalkDifficultyDTO WalkDifficulty { get; set; }
    }
}
