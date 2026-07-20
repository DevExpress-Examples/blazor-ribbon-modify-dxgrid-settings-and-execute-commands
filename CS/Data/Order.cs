using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace RibbonGetStarted.Data {
    public enum OrderState
    {
        Draft,
        Shipping,
        Paid,
        Processed
    }

    public class Order
    {
        public int Id { get; set; }
        public virtual Customer? Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual ObservableCollection<OrderItem> Items { get; set; } = new();

        public int ItemsCount { get => Items.Count; }
        public decimal TotalAmount { get => Items.Sum(d => d.Amount); }
    }

    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
        public decimal Amount
        {
            get { return (Product != null) ? (Quantity * Product.UnitPrice) : 0; }
        }
    }
}
