using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article05.Model
{
    class AreaBEL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CustomerBEL> Customer { get; set; }
    }
}
