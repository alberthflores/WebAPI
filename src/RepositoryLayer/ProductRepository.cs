using AutoMapper;
using DomainLayer;
using DomainLayer.Models;
using DtoLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    #region IProductRepository
    public interface IProductRepository
    {
        void Create(CreateProductDto productDto);
        void Delete(int id);
        List<ProductDto> GetAll();
        ProductDto GetById(int id);
        void Path(int id);
    }
    #endregion
    public class ProductRepository:IProductRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void Create(CreateProductDto productDto)
        {
            var product = mapper.Map<Product>(productDto);
            product.State = true;
            context.Products.Add(product);
            context.SaveChanges();
            
        }

        public List<ProductDto> GetAll()
        {
            var products = context.Products.Where(x => x.State == true).OrderBy(x=>x.Id).ToList();
            var dtoProducts = mapper.Map<List<ProductDto>>(products);
            return dtoProducts;
        }

        public void Path(int id)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == id);
            product.IsPublished = true;
            context.Products.Update(product);
            context.SaveChanges();
        }

        public ProductDto GetById(int id)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == id);
            return mapper.Map<ProductDto>(product);
        }
        public void Delete(int id)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == id);
            product.State = false;
            context.Products.Update(product);
            context.SaveChanges();
        }
    }
}
