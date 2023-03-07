using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NzWalk.Models.Domains
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string  Name { get; set; }
        public double Area { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public long population { get; set; }

        //Navigation Prop
        public IEnumerable<Walk> Walks { get; set; }
    }
}
