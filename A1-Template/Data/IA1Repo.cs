using A1.Models;
namespace A1.Data
{
    public interface IA1Repo
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
        Product AddProduct(Product product);
    }
}