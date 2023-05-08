using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using DocumentFormat.OpenXml.Office.CustomUI;
using static OksanaN_HW_3.ShoppingCartMain;

namespace OksanaN_HW_3
{
    public class ShoppingCartMain
    {
        public class ShoppingCart
        {
            // Properties

            public string OwnerID { get; set; }

            public Dictionary<string, (int quantity, decimal price)> items;
            public decimal CartAmount
            {
                get
                {
                    decimal sum = 0;
                    foreach (var i in items)
                    {
                        sum += i.Value.quantity * i.Value.price;
                    }
                    return sum;
                }
            }

            // Constructor
            public ShoppingCart(string name)
            {
                this.OwnerID = name;
                items = new Dictionary<string, (int, decimal)>(); //create an object of type Dictionary
            }

            //Functions
            public void AddItem(string itemName, int quantity, decimal price)
            {
                if (price <= 0)
                {
                    throw new ArgumentException("Price must be positive", nameof(price));
                }

                if (items.ContainsKey(itemName)) //search by item name to look for duplicates
                {
                    var item = items[itemName];
                    items[itemName] = (item.quantity + quantity, item.price);
                }
                else
                {
                    items[itemName] = (quantity, price);
                }
            }

            public bool RemoveItem(string itemName)
            {
                return items.Remove(itemName);
            }

        }

        static void Main()
        {
            Console.WriteLine("Please enter a OwnerID/name for Shopping Cart");
            var cart = new ShoppingCart(Console.ReadLine());

            Console.WriteLine($"A shopping cart {cart.OwnerID} is created with total amount ${cart.CartAmount}");

            // Add some items to the cart
            cart.AddItem("apple", 2, 1.10m);
            cart.AddItem("pear", 1, 2.20m);
            cart.AddItem("apple", 3, 1.10m);



            decimal totalAmount = cart.CartAmount;
            Console.WriteLine($"Total amount before Cart editing: {totalAmount}");

            Console.WriteLine("Items in the cart:");// Print the items in the cart
            foreach (var item in cart.items)
            {
                Console.WriteLine($"- {item.Key}: {item.Value.quantity} x {item.Value.price}");
            }

            bool removeItem = cart.RemoveItem("apple");
            if (removeItem)
            {
                Console.WriteLine("Item was succesfully removed from the cart");
                totalAmount = cart.CartAmount;
                Console.WriteLine("Items in the cart:"); // Print the items in the cart
                foreach (var item in cart.items)
                {
                    Console.WriteLine($"- {item.Key}: {item.Value.quantity} x {item.Value.price}");
                }
            }
            else Console.WriteLine("Item doesn't exist in the cart and can't be removed");


            Console.WriteLine($"Total amount after Cart editing: {totalAmount}");
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
