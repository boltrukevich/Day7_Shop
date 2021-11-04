using System;
using System.Collections.Generic;
using System.Linq;

namespace day7_shop
{
        public class Gift
        {
            public List<Product> products { get; set; }

            public class Product
            {
                public string full_name { get; set; }
                public string name_prefix { get; set; }
                public ProductPrices prices { get; set; }

            }
            public class ProductPrices
            {
                public Price price_min { get; set; }
            }

            public class Price
            {
                public double amount { get; set; }
            }

            public void GetProductName()
            {
                Console.WriteLine($"All products:");
                products.ForEach(x => Console.WriteLine($"Product \"{x.full_name}\" from category \"{x.name_prefix}\". Price - {x.prices.price_min.amount}."));
            }
            public void GetTotalPrice()
            {
                Console.WriteLine();
                Console.WriteLine($"Total price: {Math.Round(products.Sum(x => x.prices.price_min.amount), 2)}");
            }
            public void GetSumCheapProduct()
            {
                Console.WriteLine();
                var cheapPrice = products.Where(x => x.prices.price_min.amount < 40).ToList();
                Console.WriteLine($"Total price product with price below 40: {Math.Round(cheapPrice.Sum(x => x.prices.price_min.amount), 2)}");
            }

            public void GetCheapProduct()
            {
                Console.WriteLine();
                Console.WriteLine($"Product with the price below 25:");
                var cheapPrice = products.Where(x => x.prices.price_min.amount < 25).ToList();
                cheapPrice.ForEach(x => Console.WriteLine($"Product \"{x.full_name}\" from category \"{x.name_prefix}\". Price - {x.prices.price_min.amount}."));
            }
            public void GiftYourself()
            {
                Console.WriteLine();
                var giftBuy = GetMaxPrice();
                Console.WriteLine($"I chose the most expensive gift for myself:");
                Console.WriteLine($"Product \"{giftBuy.full_name}\" from category \"{giftBuy.name_prefix}\". Price - {giftBuy.prices.price_min.amount}.");
            }
            public void GiftMotherInLaw()
            {
                Console.WriteLine();
                var giftBuy = GetMinPrice();
                Console.WriteLine($"I chose the cheapest gift for mother-in-law:");
                Console.WriteLine($"Product \"{giftBuy.full_name}\" from category \"{giftBuy.name_prefix}\". Price - {giftBuy.prices.price_min.amount}.");
            }
            public Product GetMaxPrice()
            {
                Console.WriteLine();
                var priceMax = products.Max(x => x.prices.price_min.amount);
                return products.FirstOrDefault(x => x.prices.price_min.amount == priceMax);
            }
            public Product GetMinPrice()
            {
                Console.WriteLine();
                var priceMin = products.Min(x => x.prices.price_min.amount);
                return products.FirstOrDefault(x => x.prices.price_min.amount == priceMin);
            }
            static int Random(int index)
            {
                Random rnd = new Random();
                int value = rnd.Next(index);
                return value;
            }
            public void ProductRandomBuy()
            {
                Console.WriteLine();
                Console.WriteLine($"I chose the random gifts:");
                int index = products.Count;
                double wallet = 80;
                for (int i = Random(index); wallet > products[i].prices.price_min.amount;)
                {
                    i = Random(index);
                    wallet -= products[i].prices.price_min.amount;
                    Console.WriteLine($"Product \"{products[i].full_name}\" from category \"{products[i].name_prefix}\". Price - {products[i].prices.price_min.amount}.");
                }
            }
            public void ProductCheapesBuy()
            {
                Console.WriteLine();
                Console.WriteLine($"I chose the cheapest gifts:");
                List<Product> productsSorted = products.OrderBy(x => x.prices.price_min.amount).ToList();
                double wallet = 50;
                Console.WriteLine($"products worth 50:");
                for (int i = 0; wallet > productsSorted[i].prices.price_min.amount; i++)
                {
                    wallet -= productsSorted[i].prices.price_min.amount;
                    Console.WriteLine($"Product \"{productsSorted[i].full_name}\" from category \"{productsSorted[i].name_prefix}\". Price - {productsSorted[i].prices.price_min.amount}.");
                }
            }
        }

    }
