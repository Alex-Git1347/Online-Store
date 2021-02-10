using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class CarBodyType
    {
        public int Id { set; get; }

        public string Name { set; get; }
        public string Description { set; get; }

        public IEnumerable<Car> AllCars { get; set; }
    }
}
