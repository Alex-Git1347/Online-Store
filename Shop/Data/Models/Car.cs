using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Car
    {
        public int id { set; get; }

        public string name { set; get; }

        public string shortDesc { set; get; }

        public string longDescription { set; get; }

        public string img { set; get; }

        public uint price { set; get; }

        public bool isFavourite { set; get; }

        public bool available { set; get; }

        public int categoryID { set; get; }
         
        public virtual Category Category { set; get; }

        public string yearBorn { set; get; }

        public string colour { set; get; }

        public double volumeDVS { set; get; }

        public string cityCar { set; get; }

        public int? companyID { set; get; }

        public Company company { set; get; }
        public string modelCar { set; get; }

        public int mileageCar { set; get; }

        public string typeDVS { set; get; }

        public DateTime dataPublished { set; get; }

        public int? CarBodyId { set; get; }

        public CarBodyType CarBody { set; get; }
    }
}
