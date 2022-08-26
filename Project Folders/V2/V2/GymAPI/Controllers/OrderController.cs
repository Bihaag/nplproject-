using GymAPI.Models;
using GymServices.OrderService.Interface;
using GymServices.OrderService.Model;
using GymServices.Utils.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrders _IOrders;
        private readonly IMail _IMail;
        public OrderController(IOrders IOrders,IMail Mail)
        {
            _IOrders = IOrders;
            _IMail = Mail;
        }

        [HttpPost]
        public ActionResult InsertOrder([FromBody] UpdateOrderModel Items)
        {
            try
            {
                string body = "Your Items Are : " + Items.Desc + " @ " + Items.Total;
                _IOrders.InsertOrder(Items);
                _IMail.EmailSend( body,Items.Email,"Invoice");   
                return Ok(new { response = "123" });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public string GetOrders([FromBody] string email) 
        {
            return _IOrders.GetOrders(email);
        }

        [HttpPost]
        public string GetAllOrders()
        {
            return _IOrders.GetAllOrders();
        }

        [HttpPost]
        public string GetAllOrdersForID([FromBody] string id)
        {
            return _IOrders.GetAllOrdersForID(id);
        }

        [HttpPost]
        public ActionResult UpdateOrder([FromBody] UpdateOrderStatusModel Items)
        {
            try
            {
                _IOrders.UpdateOrderStaus(Items);
                return Ok(new { response = "123" });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
