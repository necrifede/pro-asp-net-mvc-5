using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this IEnumerable cartParam)
        {
            decimal total = 0;
            foreach (Product prod in cartParam)
            {
                total += prod.Price;
            }
            return total;
        }

        public static IEnumerable<Product> FilterByCategory(this IEnumerable productEnum, string categoryParam)
        {
            foreach (Product product in productEnum)
            {
                if (product.Category == categoryParam)
                    yield return product;
            }
        }

        public static IEnumerable<Product> Filter(this IEnumerable productEnum, Func<Product, bool> selectorParam)
        {
            foreach (Product prod in productEnum)
            {
                if (selectorParam(prod))
                    yield return prod;
            }
        }
    }
}