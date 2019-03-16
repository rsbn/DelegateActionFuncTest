using MyLibrary;
using System;
using System.Collections.Generic;

namespace testDelegateActionFunc
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(">>> Creating order with 2 items");
            Order order1 = new Order();
            order1.Customer = "John";
            order1.ID = 1;
            order1.Products.Add(new Product() { Code = "LAPTOP", Price = 1600 });
            order1.Products.Add(new Product() { Code = "OVEN", Price = 600 });

            order1.PrintStatus(DisplayOrderStatus);
            order1.PrintItems(printItems);
            Console.ReadLine();

            Console.WriteLine(">>> Item bicycle added");
            order1.Products.Add(new Product() { Code = "BICYCLE", Price = 200 });
            // PrintStatus using lambda
            //            order1.PrintStatus(DisplayOrderStatus);
            order1.PrintStatus((order) =>
            {
                Console.WriteLine($"Order ID {order.ID}, total amount {order.TotalAmount():C2} has IsClosed status {order.IsClosed}");
            });

            order1.PrintItems(printItems);
            Console.ReadLine();

            Console.WriteLine(">>> Closing order");
            // using lambda expressions instead of creating new methods
            order1.CloseOrder((msg) => Console.WriteLine(msg),
                (order) =>
                {
                    return $"Order ID {order.ID} has been closed and the items will be sent to {order.Customer}";
                });
            Console.ReadLine();
        }

        private static void printItems(List<Product> products)
        {
            Console.WriteLine("------------------------------");
            foreach (var item in products)
            {
                Console.WriteLine($"Product : {item.Code } : {item.Price:C2}");
            }
            Console.WriteLine("------------------------------");
        }

        private static void DisplayOrderStatus(Order order)
        {
            Console.WriteLine();
            Console.WriteLine("*** Order status ***");
            Console.WriteLine($"Order ID : {order.ID}");
            Console.WriteLine($"Customer :{order.Customer}");
            Console.WriteLine($"Payment Method : {order.Paymentmethod}");
            Console.WriteLine($"Total amount :{order.TotalAmount():C2}");
            Console.WriteLine($"Is Closed : {order.IsClosed}");
            Console.WriteLine("*** End of order status ***");
            Console.WriteLine();
        }
    }
}
