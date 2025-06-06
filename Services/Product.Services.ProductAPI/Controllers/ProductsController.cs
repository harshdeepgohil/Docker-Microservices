using Microsoft.AspNetCore.Mvc;
using Product.Services.ProductAPI.Data;
using Product.Services.ProductAPI.Models;
using Product.Services.ProductAPI.Models.DTO;
using System.Reflection;

namespace Product.Services.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        [HttpGet("ping")]
        public IActionResult Ping() => Ok("pong");

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("GetProducts")]
        public Response GetProducts()
        {
           Response _response  = new Response();
            try
            {
                
                _response.response = _context.Products.ToList();
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message.ToString();
            }
            return _response;
        }
        [HttpGet("dllname")]
        public IActionResult GetDllName()
        {
            var dllPath = Assembly.GetExecutingAssembly().Location;
            var dllName = Path.GetFileName(dllPath);
            return Ok(new { dllName });
        }

        [HttpPost("AddNewProduct")]
        public Response PostProducts([FromBody]Products Product)
        {
            Response _response = new Response();
            try
            {

                if(Product != null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Please Enter Data";
                }
                _context.Products.Add(Product);
                _context.SaveChanges();
                _response.IsSuccess=true;
                _response.Message = "Inserted Successfully";
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message=ex.Message.ToString();
            }
            return _response;
        }

        


    }
}
