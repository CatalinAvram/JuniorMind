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
            for (int i = 0; i < products.Length; i++)
                if (products[i].price < cheapestProduct.price)
                    cheapestProduct = products[i];
            return cheapestProduct;         
        }
    }
}
