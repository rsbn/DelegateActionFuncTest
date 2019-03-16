using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class Form1 : Form
    {
        public Order order1;
        public Form1()
        {
            InitializeComponent();
            CreateAndPopulateWithData();
        }

        private void CreateAndPopulateWithData()
        {
            order1 = new Order { Customer = "John", ID = 1 };
            order1.Products.Add(new Product() { Code = "LAPTOP", Price = 1600 });
            order1.Products.Add(new Product() { Code = "OVEN", Price = 600 });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            order1.PrintStatus(getOrderStatus);
        }

        private void getOrderStatus(Order order)
        {
            string msg = "\n*** Order status ***" + "\n" +
            $"Order ID : {order.ID}" + "\n" +
            $"Customer :{order.Customer}" + "\n" +
            $"Payment Method : {order.Paymentmethod}" + "\n" +
            $"Total amount :{order.TotalAmount():C2}" + "\n" +
            $"Is Closed : {order.IsClosed}" + "\n" +
            "*** End of order status ***" + "\n";
            Log(msg);
        }

        private void Log(string msg)
        {
            richTextBox1.Text = richTextBox1.Text + msg;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            order1.PrintItems((products) => {
                Log("\n------------------------\n");
                foreach (var item in products)
                {
                    Log($"Product : {item.Code} : {item.Price:C2}\n");
                }
                Log("------------------------\n");
            });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            order1.CloseOrder((msg) => Log(msg), (order) => $"\n Order {order.ID} was closed and the items will be sent to {order.Customer}");
        }
    }
}
