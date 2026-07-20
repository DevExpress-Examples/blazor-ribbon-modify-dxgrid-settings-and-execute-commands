using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace RibbonGetStarted.Data {

    public class DataService
    {
        List<Customer> customers = [
            new(1, "John", "Doe", "USA", "Homesville", "123 Home Lane", "+1 (323) 555-4321", "55555"),
        new(2, "Sam", "Hill", "Germany", "Berlin", "Friedrichstraße 123", "+49 (30) 1234-5678", "10117"),
        new(3, "Karen", "Holmes", "USA", "Hillsville", "45 Hill St.", "+1 (212) 555-7890", "44444"),
        new(4, "Bobbie", "Valentine", "Germany", "Munich", "Maximilianstraße 45", "+49 (89) 9876-5432", "80539"),
        new(5, "Jennie", "Fuller", "Germany", "Hamburg", "Reeperbahn 89", "+49 (40) 2233-4455", "20359"),
        new(6, "Albert", "Menendez", "USA", "Chicago", "933 Heart St. Suite", "+1 (312) 555-6789", "9900"),
        new(7, "Frank", "Frankson", "France", "Paris", "25 Rue de Rivoli", "+33 (1) 23-45-67-89", "75004"),
        new(8, "Christa", "Christie", "UK", "London", "221B Baker Street", "+44 (20) 7946-0958", "NW1 6XE"),
        new(9, "Jimmie", "Jones", "USA", "Newman", "900 Newman Center.", "+1 (312) 555-6789", "89123"),
        new(10, "Alfred", "Newman", "Germany", "Frankfurt", "Goethestraße 10", "+49 (69) 1122-3344", "60313"),
        new(11, "Benjamin", "Johnson", "UK", "Manchester", "50 Deansgate", "+44 (161) 555-6789", "M3 2BW"),
        new(12, "Alex", "James", "USA", "Los Angeles", "349 Graphic Design L", "+1 (305) 555-9876", "12211"),
        new(13, "Beau", "Alessandro", "UK", "Birmingham", "30 New Street", "+44 (121) 555-4321", "B2 4ND"),
        new(14, "Bruce", "Cambell", "USA", "San Francisco", "350 Market Street", "+1 (415) 555-1234", "94103"),
        new(15, "Cindy", "Haneline", "USA", "Houston", "600 Main Street", "+1 (713) 555-5678", "77002"),
        new(16, "Andrea", "Deville", "France", "Bordeaux", "14 Cours de l'Intendance", "+33 (5) 56-78-90-12", "33000"),
        new(17, "Anita", "Ryan", "UK", "Cardiff", "30 Castle Street", "+44 (29) 555-1234", "CF10 1BT"),
        new(18, "George", "Bunkelman", "UK", "Liverpool", "100 Albert Dock", "+44 (151) 555-6789", "L3 4AA"),
        new(19, "Anita", "Cardle", "USA", "Seattle", "1200 Pine Street", "+1 (206) 555-8765", "98101"),
        new(20, "Andrew", "Carter", "Germany", "Stuttgart", "Königstraße 20", "+49 (711) 6543-2100", "70173"),
        new(21, "Almas", "Bunch", "USA", "Boston", "75 Beacon Street", "+1 (617) 555-4321", "02108"),
        new(22, "Abigail", "Hazel", "UK", "Glasgow", "75 Buchanan Street", "+44 (141) 555-4321", "G1 3HL"),
        new(23, "Anthony", "Vicars", "Germany", "Düsseldorf", "Königsallee 85", "+49 (211) 7894-5678", "40212"),
        new(24, "Dora", "Geeter", "UK", "Bristol", "20 Queen Square", "+44 (117) 555-8765", "BS1 4ND"),
        new(25, "Anthony", "Boyd", "USA", "Denver", "1500 Blake Street", "+1 (303) 555-7890", "80202"),
        new(26, "Dora", "Catto", "USA", "Atlanta", "200 Peachtree Street", "+1 (404) 555-2345", "30303"),
    ];
        static DateTime restockDate = DateTime.Today.AddMonths(1);
        List<Product> products = [
            new Product { ProductID = 1, ProductName = "Chai", SupplierID = 1, CategoryID = 1, QuantityPerUnit = "10 boxes x 20 bags", UnitPrice = 18.00m, UnitsInStock = 39, UnitsOnOrder = 0, ReorderLevel = 10, Discontinued = false },
        new Product { ProductID = 2, ProductName = "Chang", SupplierID = 1, CategoryID = 1, QuantityPerUnit = "24 - 12 oz bottles", UnitPrice = 19.00m, UnitsInStock = 17, UnitsOnOrder = 40, ReorderLevel = 25, Discontinued = false, RestockDate = restockDate },
        new Product { ProductID = 3, ProductName = "Aniseed Syrup", SupplierID = 1, CategoryID = 2, QuantityPerUnit = "12 - 550 ml bottles", UnitPrice = 10.00m, UnitsInStock = 13, UnitsOnOrder = 70, ReorderLevel = 25, Discontinued = false, RestockDate = restockDate },
        new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", SupplierID = 2, CategoryID = 2, QuantityPerUnit = "48 - 6 oz jars", UnitPrice = 22.00m, UnitsInStock = 53, UnitsOnOrder = 0, ReorderLevel = 0, Discontinued = false },
        new Product { ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", SupplierID = 2, CategoryID = 2, QuantityPerUnit = "36 boxes", UnitPrice = 21.35m, UnitsInStock = 0, UnitsOnOrder = 0, ReorderLevel = 0, Discontinued = true },
        new Product { ProductID = 6, ProductName = "Grandma's Boysenberry Spread", SupplierID = 3, CategoryID = 2, QuantityPerUnit = "12 - 8 oz jars", UnitPrice = 25.00m, UnitsInStock = 120, UnitsOnOrder = 0, ReorderLevel = 25, Discontinued = false },
        new Product { ProductID = 7, ProductName = "Uncle Bob's Organic Dried Pears", SupplierID = 3, CategoryID = 7, QuantityPerUnit = "12 - 1 lb pkgs.", UnitPrice = 30.00m, UnitsInStock = 15, UnitsOnOrder = 0, ReorderLevel = 10, Discontinued = false, RestockDate = restockDate },
        new Product { ProductID = 8, ProductName = "Northwoods Cranberry Sauce", SupplierID = 3, CategoryID = 2, QuantityPerUnit = "12 - 12 oz jars", UnitPrice = 40.00m, UnitsInStock = 6, UnitsOnOrder = 0, ReorderLevel = 0, Discontinued = false, RestockDate = restockDate },
        new Product { ProductID = 9, ProductName = "Mishi Kobe Niku", SupplierID = 4, CategoryID = 6, QuantityPerUnit = "18 - 500 g pkgs.", UnitPrice = 97.00m, UnitsInStock = 29, UnitsOnOrder = 0, ReorderLevel = 0, Discontinued = true },
        new Product { ProductID = 10, ProductName = "Ikura", SupplierID = 4, CategoryID = 8, QuantityPerUnit = "12 - 200 ml jars", UnitPrice = 31.00m, UnitsInStock = 31, UnitsOnOrder = 0, ReorderLevel = 0, Discontinued = false },
        new Product { ProductID = 11, ProductName = "Queso Cabrales", SupplierID = 5, CategoryID = 4, QuantityPerUnit = "1 kg pkg.", UnitPrice = 21.00m, UnitsInStock = 22, UnitsOnOrder = 30, ReorderLevel = 30, Discontinued = false },
        new Product { ProductID = 12, ProductName = "Queso Manchego La Pastora", SupplierID = 5, CategoryID = 4, QuantityPerUnit = "10 - 500 g pkgs.", UnitPrice = 38.00m, UnitsInStock = 86, UnitsOnOrder = 0, ReorderLevel = 0, Discontinued = false },
        new Product { ProductID = 13, ProductName = "Konbu", SupplierID = 6, CategoryID = 8, QuantityPerUnit = "2 kg box", UnitPrice = 6.00m, UnitsInStock = 24, UnitsOnOrder = 0, ReorderLevel = 5, Discontinued = false },
        new Product { ProductID = 14, ProductName = "Tofu", SupplierID = 6, CategoryID = 7, QuantityPerUnit = "40 - 100 g pkgs.", UnitPrice = 23.25m, UnitsInStock = 35, UnitsOnOrder = 0, ReorderLevel = 0, Discontinued = false },
        new Product { ProductID = 15, ProductName = "Genen Shouyu", SupplierID = 6, CategoryID = 2, QuantityPerUnit = "24 - 250 ml bottles", UnitPrice = 15.50m, UnitsInStock = 39, UnitsOnOrder = 0, ReorderLevel = 5, Discontinued = false },
        new Product { ProductID = 16, ProductName = "Pavlova", SupplierID = 7, CategoryID = 3, QuantityPerUnit = "32 - 500 g boxes", UnitPrice = 17.45m, UnitsInStock = 29, UnitsOnOrder = 0, ReorderLevel = 10, Discontinued = false },
        new Product { ProductID = 17, ProductName = "Alice Mutton", SupplierID = 7, CategoryID = 6, QuantityPerUnit = "20 - 1 kg tins", UnitPrice = 39.00m, UnitsInStock = 0, UnitsOnOrder = 0, ReorderLevel = 0, Discontinued = true },
        new Product { ProductID = 18, ProductName = "Carnarvon Tigers", SupplierID = 7, CategoryID = 8, QuantityPerUnit = "16 kg pkg.", UnitPrice = 62.50m, UnitsInStock = 42, UnitsOnOrder = 0, ReorderLevel = 0, Discontinued = false },
        new Product { ProductID = 19, ProductName = "Teatime Chocolate Biscuits", SupplierID = 8, CategoryID = 3, QuantityPerUnit = "10 boxes x 12 pieces", UnitPrice = 9.20m, UnitsInStock = 25, UnitsOnOrder = 0, ReorderLevel = 5, Discontinued = false },
        new Product { ProductID = 20, ProductName = "Sir Rodney's Marmalade", SupplierID = 8, CategoryID = 3, QuantityPerUnit = "30 gift boxes", UnitPrice = 81.00m, UnitsInStock = 40, UnitsOnOrder = 0, ReorderLevel = 0, Discontinued = false }
        ];
        List<Category> categories = [
            new Category { CategoryID = 1, CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" },
        new Category { CategoryID = 2, CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" },
        new Category { CategoryID = 3, CategoryName = "Confections", Description = "Desserts, candies, and sweet breads" },
        new Category { CategoryID = 4, CategoryName = "Dairy Products", Description = "Cheeses" },
        new Category { CategoryID = 5, CategoryName = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal" },
        new Category { CategoryID = 6, CategoryName = "Meat/Poultry", Description = "Prepared meats" },
        new Category { CategoryID = 7, CategoryName = "Produce", Description = "Dried fruit and bean curd" },
        new Category { CategoryID = 8, CategoryName = "Seafood", Description = "Seaweed and fish" }
        ];
        List<Order> orders;

        public DataService()
        {
            orders = GenerateOrders(150);
        }
        public IEnumerable<Customer> GetCustomers() => customers;
        public IEnumerable<Product> GetProducts() => products;
        public IEnumerable<Category> GetCategories() => categories;
        public IEnumerable<Order> GetOrders() => orders;
        List<Order> GenerateOrders(int count)
        {
            Random random = new Random();
            var generatedOrders = new List<Order>();
            for (int i = 1; i <= count; i++)
            {
                var customer = customers[random.Next(customers.Count)];
                var order = new Order
                {
                    Id = i,
                    Customer = customer,
                    OrderDate = DateTime.Now.AddDays(-random.Next(1, 500)),
                    Items = new ObservableCollection<OrderItem>()
                };

                int itemsCount = random.Next(1, 5);
                for (int j = 0; j < itemsCount; j++)
                {
                    var product = products[random.Next(products.Count)];
                    order.Items.Add(new OrderItem
                    {
                        Id = i * 10 + j,
                        Order = order,
                        Product = product,
                        Quantity = random.Next(1, 10)
                    });
                }

                customer.Orders.Add(order);
                generatedOrders.Add(order);
            }
            return generatedOrders;
        }
    }
}
