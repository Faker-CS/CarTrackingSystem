using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTrackeingDomain.Domain
{
    public class DTOstock
    {
        public int plate {  get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public DateTime Time { get; set; }
    }
}
