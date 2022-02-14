using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Product
    {
        /*{ 

   "id":1, 

   "name": "Premium Roast Coffee", 

   "price": 1.19, 

   "mrp": 1.19, 

   "stock": 3, 

   "isPublished": false, 

   “state”: true 

} */
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Mrp { get; set; }
        public int Stock { get; set; }
        public bool IsPublished { get; set; }
        public bool State { get; set; }

    }
}
