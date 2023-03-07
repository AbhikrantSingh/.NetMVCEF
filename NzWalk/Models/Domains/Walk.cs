using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzWalk.Models.Domains
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDiffcultyId { get; set; }

        //Nav Prop
        public Models.Domains.Region Region { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
