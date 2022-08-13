//using A1.Data;
using A1.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace A1.Data
{
    public class A1Repo : IA1Repo
    {
        private readonly A1DbContext _dbContext;
        public A1Repo(A1DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //IEnumerable<Product> _products;

        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> products = _dbContext.Products.ToList<Product>();
            return products;
        }

        public Product GetProduct(int id)
        {
            Product p = _dbContext.Products.FirstOrDefault(e => e.Id == id);
            return p;
        }

        public Product AddProduct(Product product)
        {
            EntityEntry<Product> e = _dbContext.Products.Add(product);
            Product p = e.Entity;
            _dbContext.SaveChanges();
            return p;
        }
    }
}