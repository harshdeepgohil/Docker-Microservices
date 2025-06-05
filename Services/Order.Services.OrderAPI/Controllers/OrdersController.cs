using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order.Services.OrderAPI.Data;
using Order.Services.OrderAPI.Models;
using Order.Services.OrderAPI.Models.DTO;

namespace Order.Services.OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public OrdersController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet("GetAllOrders")]
        public  List<Orders> GetAllOrders()
        {
             return  _db.Orders.ToList();
        }

        [HttpPost("AddNewOrder")]
        public async Task<ActionResult> AddNewOrder([FromBody]OrdersViewModel order)
        {
            var orderEntity = _mapper.Map<Orders>(order);
             _db.Orders.Add(orderEntity);

            await _db.SaveChangesAsync();   

            return Ok(orderEntity);
        }
    }
}
