using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibrary
{

    public class Order
    {
        public enum enumPaymentMethod
        {
            Credit = 1,
            Debt = 2,
            Cash = 3
        }
        public delegate void PrintOrderItems(List<Product> products);
        public delegate void PrintOrderStatus(Order order);

        private bool _IsClosed { get; set; }
        public int ID { get; set; }
        public string Customer { get; set; }
        public List<Product> Products;
        public enumPaymentMethod Paymentmethod { get; set; } = enumPaymentMethod.Cash;
        public bool IsClosed
        {
            get
            { return _IsClosed;
            }
        }
        public decimal TotalAmount()
        {
            return Products.Sum(x => x.Price);
        }
        public Order()
        {
            Products = new List<Product>();
        }
        /*
         * Func -  the last parameter is always an output so, it always returns a value
         * Action - never returns a value
         * Below I created an Action<> to do something with the Func<> returned value - just for practice purposes =)
         */
        public void CloseOrder(Action<string> alertMessage, Func<Order,string> buildMessage) 
        {
            _IsClosed = true;
            string message = buildMessage(this);
            alertMessage(message);
        }
        public void PrintItems(PrintOrderItems printOrderItems)
        {
            printOrderItems(Products);
        }
        public void PrintStatus(PrintOrderStatus getOrderStatus)
        {
            getOrderStatus(this);
        }
    }
}
