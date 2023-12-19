using SupplyScopeMVC.Domain.Interfaces;
using SupplyScopeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyScopeMVC.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _contex;
        public ProductRepository(Context context)
        {
            _contex = context;
        }

        public void DeleteProduct(int productId)
        {
            var product = _contex.Products.Find(productId);
            if (product != null)
            {
                _contex.Products.Remove(product);
                _contex.SaveChanges();
            }
        }

        public int AddProduct(Product product)
        {
            _contex.Products.Add(product);
            _contex.SaveChanges();
            return product.Id;
        }

        public IQueryable<Product> GetProductsByTypeId(int typeId)
        {
            var products = _contex.Products.Where(p => p.TypeId == typeId);
            return products;
        }

        public Product GetProductById(int productId)
        {
            var product = _contex.Products.FirstOrDefault(p => p.Id == productId);
            return product;
        }

        public IQueryable<Tag> GetAllTags()
        {
            var tags = _contex.Tags;
            return tags;
        }

        public IQueryable<Domain.Model.Type> GetAllTypes()
        {
            var types = _contex.Types;
            return types;
        }
    }
}
