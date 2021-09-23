using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
namespace JsonUnion
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ").Take(2).Select(x => Convert.ToInt32(x)).ToArray();
            (int n, int m) = (input[0], input[1]);

            string[] jsons = new string[n];
            for (int i = 0; i < n; i++)
            {
                jsons[i] = Console.ReadLine();
            }

            var result = new OfferCollection();

            for (int i = 0; i < n; i++)
            {
                var offers = JsonSerializer.Deserialize<OfferCollection>(jsons[i]).offers;
                result.offers.AddRange(offers);
                if (result.offers.Count >= m)
                {
                    result.offers = result.offers.Take(m).ToList();
                    break;
                }
            }

            Console.WriteLine(JsonSerializer.Serialize(result));
        }
    }
    class Offer
    {
        public string offer_id { get; set; }
        public int market_sku { get; set; }
        public int price { get; set; }
    }
    class OfferCollection
    {
        public List<Offer> offers { get; set; } = new List<Offer>();
    }
}
