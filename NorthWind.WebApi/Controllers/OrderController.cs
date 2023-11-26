using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NorthWind.UnitOfWork;

namespace NorthWind.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    [Authorize]
    public class OrderController : Controller 
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetPaginatedOrder/{page:int}/{rows:int}")]
        public IActionResult GetPaginatedOrder(int page, int rows)
        {
            return Ok(_unitOfWork.Order.GetPaginatedOrder(page, rows));
        }

        [HttpGet]
        [Route("GetOrderById/{orderId:int}")]
        public IActionResult GetOrderById(int orderId) 
        {
            return Ok(_unitOfWork.Order.GetOrderById(orderId));
        }
    }
}
