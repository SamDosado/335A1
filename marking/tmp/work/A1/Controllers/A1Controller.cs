using Microsoft.AspNetCore.Mvc;
using A1.Data;
using A1.Models;
using A1.Dtos;
using Microsoft.AspNetCore.HttpOverrides;
using System.Linq;
using System;
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
            string respHeader = "image/png";
            return PhysicalFile(imgDir, respHeader);
            //return Ok(imgDir);
        }

        [HttpGet]
        [Route("GetFavicon")]
        public IActionResult getFavicon()
        {
            string path = Directory.GetCurrentDirectory();
            string imgDir = Path.Combine(path, "Logos\\Logo-192x192.png");
            string respHeader = "image/png";
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
            IEnumerable<Product> products = _repo.GetAllProducts();


            return Ok(products);
            //return Ok(_repo.GetAllProducts());
        }

        [HttpGet]
        [Route("GetItems/{par_name}")]
        public ActionResult<IEnumerable<Product>> getItems(string par_name)
        {
            IEnumerable<Product> p = _repo.GetAllProducts();
            List<Product> products = new List<Product>();
            foreach (Product product in p)
            {
                if (product.Name.ToLower().Contains(par_name))
                {
                    products.Add(product);
                    //products.
                }
            } 

            return Ok(products);
            //return Ok(_repo.GetAllProducts());
        }

        [HttpGet]
        [Route("ItemPhoto/{id}")]
        public IActionResult getItemPhoto(string id)
        {
            string path = Directory.GetCurrentDirectory();
            string filename = Path.Combine(path, $"ItemsImages\\{id}.jpg" );
            string respHeader = "image/jpg";
            //if (!System.IO.File.Exists(filename))
            //{
            //    filename = Path.Combine(path, "ItemsImages\\default.png");
            //    respHeader = "image/png";
            //}
            return PhysicalFile(filename, respHeader);
        }

        [HttpPost]
        [Route("WriteComment")]
        public ActionResult<CommentDto> AddComment(CommentDto comment)
        {
            var IP = Request.HttpContext.Connection.RemoteIpAddress;
            Comment c = new Comment {UserComment = comment.UserComment, Name = comment.Name, IP = IP.ToString(), Time = DateTime.Now.ToString() };
            Comment addedComment = _repo.AddComment(c);
            return Ok(addedComment.UserComment);
        }

        [HttpGet]
        [Route("GetComments")]
        public ActionResult<IEnumerable<Comment>> GetLastFiveComments()
        {
            IEnumerable<Comment> comments = _repo.GetAllComments();
            List<Comment> LastFiveComments = new List<Comment>();
            foreach(Comment comment in comments.Skip(Math.Max(0, comments.Count() - 5)))
            {
                LastFiveComments.Add(comment);
            }
            return Ok(LastFiveComments);
            //return Ok(_repo.GetAllProducts());
        }


    }
}