using DAL.Entities;
using LOGIC.SettingsLogic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Web;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;

namespace MASAB2B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class OrderController : ControllerBase
    {
 

        [Route("GetAllOrders")]
        [HttpGet]
        public async Task<List<Orders>> GetOrders()
        {
            OrdersLogic pro = new OrdersLogic();
            var list = await pro.GetAllOrders();

            return list;

        }

        [Route("SaveOrders")]
        [HttpPost]

        public async Task<string> SaveOrderss(Orders obj)
        {


            OrdersLogic pro = new OrdersLogic();

            var get = await pro.CreateNewOrder(obj);
        
            if (get != "false")
            {
                return get.ToString();
            }
            else
            {
                return "false";
            }




        }

        [Route("GetByIdOrders")]
        [HttpGet]
        public IActionResult GetByIdOrderss(string id)
        {

            OrdersLogic cat = new OrdersLogic();
            var get = cat.getbyidOrderss(id);
            return Ok(get);


        }

        [Route("DeleteOrders")]
        [HttpGet]
        public string DeleteOrders(string id)
        {

            OrdersLogic cat = new OrdersLogic();
            var get = cat.DeleteOrderss(id);
            return get;


        }

        [Route("GetAllOrderItems")]
        [HttpGet]
        public async Task<List<OrderItems>> GetOrderItemss()
        {
            OrderItemsLogic pro = new OrderItemsLogic();
            var list = await pro.GetAllOrderItems();

            return list;

        }

        [Route("SaveOrdersItems")]
        [HttpPost]

        public async void SaveOrdersItems(OrderItems[] obj)
        {


            OrderItemsLogic pro = new OrderItemsLogic();

            foreach (var item in obj)
            {
              
               
                await pro.CreateNewOrder(item);
            }
        
        }

        [Route("GetByIdOrdersItems")]
        [HttpGet]
        public async Task<List<OrderItems>> GetByIdOrderItemss(string id)
        {

            OrderItemsLogic pro = new OrderItemsLogic();
            var list = await pro.getbyidOrderItemss(id);

            return list;


        }

        [Route("DeleteOrderItems")]
        [HttpGet]
        public string DeleteOrderItemss(string id)
        {

            OrdersLogic cat = new OrdersLogic();
            var get = cat.DeleteOrderss(id);
            return get;


        }

     
        [Route("Saveratings")]
        [HttpPost]

        public async Task<string> SaveRatingss(rating obj)
        {


            RatingLogic pro = new RatingLogic();

            var get = await pro.CreateNewrating(obj);

            if (get != "false")
            {
                return get.ToString();
            }
            else
            {
                return "false";
            }




        }

        [Route("GetByIdRatings")]
        [HttpGet]
        public IActionResult GetByIdRatingss(string id)
        {

            RatingLogic cat = new RatingLogic();
            var get = cat.getbyidratings(id);
            return Ok(get);


        }

        [Route("DeleteRatings")]
        [HttpGet]
        public string DeleteRatings(string id)
        {

            RatingLogic cat = new RatingLogic();
            var get = cat.Deleteratings(id);
            return get;


        }

        [Route("GetAllRatingItems")]
        [HttpGet]
        public async Task<List<rating>> GetRatingItemss()
        {
            RatingLogic pro = new RatingLogic();
            var list = await pro.GetAllrating();

            return list;

        }
    }
}
