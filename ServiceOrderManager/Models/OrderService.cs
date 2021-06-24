using ServiceOrderManager.Models.Enums;
using System;

namespace ServiceOrderManager.Models
{
    public class OrderService
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int InternalControlOS { get; set; }
        public DateTime Initial { get; set; }
        public DateTime Finish { get; set; }
        public DateTime Prevision { get; set; }
        public Equipment Equipment { get; set; }
        public Double Value { get; set; }
        public Status Status { get; set; }
        public Priority Priority{ get; set; }

        public OrderService()
        {
        }

        public OrderService(int id, string description, DateTime prevision, Equipment equipment, double value, Status status, Priority priority)
        {
            Id = id;
            Description = description;      
            Initial = DateTime.Now;
            Prevision = prevision;
            Equipment = equipment;
            Value = value;
            Status = status;
            Priority = priority;
        }

        public void SetCompleted()
        {
            this.InternalControlOS = Equipment.InternalControl;
            this.Finish = DateTime.Now;
            this.Status = Status.Completed;
        }
    }
}
