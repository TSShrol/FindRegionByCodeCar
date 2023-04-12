using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string NameRegion { get; set; }
        IEnumerable<CarNumberCode> CarNumberCodes { get; set; };
    }
}
