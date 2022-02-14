using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer
{
    public class CreateProductDto
    {
        public CreateProductDto()
        {
            IsPublished = false;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Mrp { get; set; }
        public int Stock { get; set; }
        public bool IsPublished { get; set; }
    }

    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Mrp { get; set; }
        public int Stock { get; set; }
        public bool IsPublished { get; set; }
        public bool State { get; set; }
    }
}
