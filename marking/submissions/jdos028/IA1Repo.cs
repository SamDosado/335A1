using A1.Models;
namespace A1.Data
{
    public interface IA1Repo
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Comment> GetAllComments();
        Product GetProduct(string id);
        Product AddProduct(Product product);
        Comment AddComment(Comment comment);
    }
}