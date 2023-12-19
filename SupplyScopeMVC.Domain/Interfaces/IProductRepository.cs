using SupplyScopeMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyScopeMVC.Domain.Interfaces
{
    public interface IProductRepository
    {
        void DeleteProduct(int productId);
        int AddProduct(Product product);
        IQueryable<Product> GetProductsByTypeId(int typeId);
        Product GetProductById(int productId);
        IQueryable<Tag> GetAllTags();
        IQueryable<Domain.Model.Type> GetAllTypes();
    }
}
