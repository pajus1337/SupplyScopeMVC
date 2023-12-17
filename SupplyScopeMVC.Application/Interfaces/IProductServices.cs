using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyScopeMVC.Application.Interfaces
{
    public interface IProductServices
    {
        List<int> GetAllProducts();
    }
}
