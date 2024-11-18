using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTrackeingDomain.Domain
{
    public interface IDao
    {
        public bool IStock(DTOstock Stock);
        public List<DTOstock> Retrieve(int plate , DateTime startTime, DateTime endTime);
    }
}
