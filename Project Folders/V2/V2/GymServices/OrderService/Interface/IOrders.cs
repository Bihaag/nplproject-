using GymAPI.Models;
using GymServices.OrderService.Model;

namespace GymServices.OrderService.Interface
{
    public interface IOrders
    {
        void InsertOrder(UpdateOrderModel Items);

        string GetOrders(string email);

        string GetAllOrders();

        string GetAllOrdersForID(string id);

        void UpdateOrderStaus(UpdateOrderStatusModel Items);
    }
}
