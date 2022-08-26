using GymAPI.Models;
using GymServices.OrderService.Interface;
using GymServices.OrderService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymServices.OrderService
{
    public class Orders : IOrders
    {
        SqlHelper sqlHelper = new SqlHelper("server=tcp:nplappserver.database.windows.net,1433;Initial Catalog=nplDB;Persist Security Info=False;User ID=npladmin;Password=NPLgym007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        public void InsertOrder(UpdateOrderModel Items)
        {
            string output = sqlHelper.ExecuteInLineSql($"EXEC InsertOrder '{Items.Desc}','{Items.Email}','{Items.Status}','{Items.Meta}','{Items.Total}'");
        }

        public string GetOrders(string email) 
        {
            string output = sqlHelper.ExecuteInLineSql($"SELECT * FROM Orders WHERE Email = '{email}'");
            return output;
        }

        public string GetAllOrders()
        {
            string output = sqlHelper.ExecuteInLineSql($"SELECT * FROM Orders");
            return output;
        }

        public string GetAllOrdersForID(string id)
        {
            string output = sqlHelper.ExecuteInLineSql($"SELECT * FROM Orders WHERE OrderID = {id}");
            return output;
        }

        public void UpdateOrderStaus(UpdateOrderStatusModel Items)
        {
            string output = sqlHelper.ExecuteInLineSql($"EXEC UpdateOrder '{Items.id}','{Items.status}'");
        }
    }
}
