using SupplyScopeMVC.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyScopeMVC.Application.Services
{
    public class ProductServices : IProductServices
    {
        // private readonly IProductRepository = _productRepository;

      /*  public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository
        } */

        public List<int> GetAllProducts()
        {
            var products = new List<int>();
            return products;
        }
    }
}
