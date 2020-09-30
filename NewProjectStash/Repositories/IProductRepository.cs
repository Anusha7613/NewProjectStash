using NewProjectStash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewProjectStash.Repositories
{
   public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();


        int AddNewProduct(Product product);
        int EditProduct(Product product);
        Product GetProductById(int id);
    }
}
