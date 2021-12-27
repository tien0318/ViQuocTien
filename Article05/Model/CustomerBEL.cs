using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article05.Model
{
    class CustomerBEL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AreaBEL Area { get; set; }
        public string AreaName
        {
            get { return Area.Name; }
        }
    }
}
