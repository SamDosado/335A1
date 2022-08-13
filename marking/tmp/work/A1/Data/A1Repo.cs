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

        public IEnumerable<Comment> GetAllComments()
        {
            IEnumerable<Comment> comments = _dbContext.Comments.ToList<Comment>(); 
            return comments;
        }

        public Product GetProduct(string id)
        {
            Product p = _dbContext.Products.FirstOrDefault(e => e.Id.Equals(id) );
            return p;
        }

        public Product AddProduct(Product product)
        {
            EntityEntry<Product> e = _dbContext.Products.Add(product);
            Product p = e.Entity;
            _dbContext.SaveChanges();
            return p;
        }

        public Comment AddComment(Comment comment)
        {
            EntityEntry<Comment> e = _dbContext.Comments.Add(comment);
            Comment c = e.Entity;
            _dbContext.SaveChanges();
            return c;
        }
    }
}