using DtoLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    #region ProductService
    public interface IProductService
    {
        void Create(CreateProductDto productDto);
        void Delete(int id);
        List<ProductDto> GetAll();
        ProductDto GetById(int id);
        void Path(int id);
    }
    #endregion
    public class ProductService:IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Create(CreateProductDto productDto)
        {
            productRepository.Create(productDto);

        }

        public List<ProductDto> GetAll()
        {
           
            return productRepository.GetAll();
        }

        public ProductDto GetById(int id)
        {
            
            return productRepository.GetById(id);
        }
        public void Delete(int id)
        {
            productRepository.Delete(id);
        }

        public void Path(int id)
        {
            productRepository.Path(id);
        }
    }
}
