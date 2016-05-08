using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*Ai un coș plin de produse. Dacă cunoști prețul fiecărui produs în parte:
    1.Calculează care e totalul de plată pentru coșul cu cumpărături
    2.Găsește și care e cel mai ieftin produs din coș
    3.Elimină cel mai scump produs din coș
    4.Adaugă un nou produs în coș
    5.Calculează prețul mediu*/
namespace Basket
{
    public struct Product
    {
        public string name;
        public double price;

        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
    }

    [TestClass]
    public class BasketTests
    {
        [TestMethod]
        public void TotalPrice()
        {
            var products = new Product[] { new Product("Meat", 3), new Product("Bread", 5) };
            Assert.AreEqual(8, CalculateTotalPrice(products));
        }

        [TestMethod]
        public void CheapestProduct()
        {
            var products = new Product[] { new Product("Meat", 3), new Product("Bread", 5), new Product("Potatoes", 2) };
            Product cheapestProduct = new Product("Potatoes", 2);
            Assert.AreEqual(cheapestProduct, FindCheapestProduct(products));
        }

        [TestMethod]
        public void ReduceCosts()
        {
            var products = new Product[] { new Product("Meat", 3), new Product("Bread", 5), new Product("Potatoes", 2) };
            var reducedBasket = new Product[] { new Product("Meat", 3), new Product("Potatoes", 2) };
            CollectionAssert.AreEqual(reducedBasket, EliminateMostExpensiveProduct(products));
        }

        [TestMethod]
        public void HighestPriceProductPosition()
        {
            var products = new Product[] { new Product("Meat", 3), new Product("Bread", 5), new Product("Potatoes", 2) };
            Assert.AreEqual(1, FindMostExpensiveProductPosition(products));
        }

        [TestMethod]
        public void NewProductAdded()
        {
            var initialBasket = new Product[] { new Product("Meat", 3), new Product("Bread", 5), new Product("Potatoes", 2) };
            var increasedBasket = new Product[] { new Product("Meat", 3), new Product("Bread", 5), new Product("Potatoes", 2), new Product("Toothpaste", 7) };
            CollectionAssert.AreEqual(increasedBasket, AddNewProduct(initialBasket, increasedBasket[increasedBasket.Length - 1]));
        }

        [TestMethod]
        public void AveragePrice()
        {
            var products = new Product[] { new Product("Meat", 3), new Product("Bread", 5), new Product("Potatoes", 2) };
            Assert.AreEqual(3.33, ComputeAveragePrice(products), 0.01);
        }

        double CalculateTotalPrice(Product[] products)
        {
            double totalPrice = 0;
            for (int i = 0; i < products.Length; i++)
                totalPrice += products[i].price;
            return totalPrice;
        }

        Product FindCheapestProduct(Product[] products)
        {
            Product cheapestProduct = products[0];
            for (int i = 1; i < products.Length; i++)
                if (products[i].price < cheapestProduct.price)
                    cheapestProduct = products[i];
            return cheapestProduct;         
        }

        int FindMostExpensiveProductPosition(Product[] products)
        {
            Product mostExpensiveProduct = products[0];
            int position = 0;
            for (int i = 1; i < products.Length; i++)
                if (products[i].price > mostExpensiveProduct.price)
                {
                    mostExpensiveProduct = products[i];
                    position = i;
                }
            return position;
        }

        Product[] EliminateMostExpensiveProduct(Product[] products)
        {
            int mostExpensiveProductPosition = FindMostExpensiveProductPosition(products);
            for (int i = mostExpensiveProductPosition; i < products.Length - 1; i++)
                products[i] = products[i + 1];
            Array.Resize(ref products, products.Length - 1);
            return products;
        }

        Product[] AddNewProduct(Product[] products, Product newProduct)
        {
            Array.Resize(ref products, products.Length + 1);
            products[products.Length - 1] = newProduct;
            return products;
        }

        double ComputeAveragePrice(Product[] products)
        {
            return CalculateTotalPrice(products) / products.Length;
        }
    }
}
