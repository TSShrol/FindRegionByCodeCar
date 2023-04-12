using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class CarNumberCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
    }
}
