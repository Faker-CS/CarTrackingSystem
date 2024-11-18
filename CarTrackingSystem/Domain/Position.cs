using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTrackeingDomain.Domain
{
    public class Position
    {
        public int Id {  get; set; }
        public int X { get => Random.Next(10, 100); }
        public int Y { get => Random.Next(10, 100); }
        public DateTime DateStamp {  get => DateTime.Now; }

        Random Random = new Random();


    }
}
