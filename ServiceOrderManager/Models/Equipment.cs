using System;
using System.Collections.Generic;

namespace ServiceOrderManager.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int InternalControl { get; set; }
        public string Details { get; set; }
        public ICollection<OrderService> ServiceOrders { get; set; } = new List<OrderService>();

        public Equipment()
        {
        }

        public Equipment(int id, string description, int internalControl, string details)
        {
            Id = id;
            Description = description;
            InternalControl = internalControl;
            Details = details;
        }

        public void AddServiceOrder (OrderService orderService)
        {
            ServiceOrders.Add(orderService);
        }

        public void RemoveServiceOrder (OrderService orderService)
        {
            ServiceOrders.Remove(orderService);
        }
    }
}
