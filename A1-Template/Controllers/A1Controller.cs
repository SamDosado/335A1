using Microsoft.AspNetCore.Mvc;
using A1.Data;
using A1.Models;
namespace A1.Controllers
{
    [ApiController]
    [Route("api")]
    
    public class A1Controller : Controller
    {
        private readonly IA1Repo _repo;
        public A1Controller(IA1Repo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("GetLogo")]
        public IActionResult getLogo()
        {
            string path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "Logos\\Logo.png");
            String respHeader = "image/png";
            return PhysicalFile(imgDir, respHeader);
            //return Ok(imgDir);
        }

        [HttpGet]
        [Route("GetFavicon")]
        public IActionResult getFavicon()
        {
            string path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "Logos\\Logo-192x192.png");
            String respHeader = "image/png";
            return PhysicalFile(imgDir, respHeader);
            //return Ok(imgDir);
        }

        [HttpGet]
        [Route("GetVersion")]
        public IActionResult getVersion()
        {
            //How do we dynamically get the version number?
            return Ok("1.0.0");
        }
        
        [HttpGet]
        [Route("AllItems")]
        public ActionResult<IEnumerable<Product>> getAllItems()
        {
            IEnumerable < Product > products = _repo.GetAllProducts();
            Console.WriteLine("Products loaded");
            Console.WriteLine(products);
            return Ok(products);
            //return Ok(_repo.GetAllProducts());


        }
    }
}