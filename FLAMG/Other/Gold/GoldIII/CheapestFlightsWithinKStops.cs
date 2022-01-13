using System;
using System.Collections.Generic;
using System.Text;

namespace FLAMG.Other.Gold.GoldIII
{
    public class CheapestFlightsWithinKStops
    {
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {
            // write your code here
            if (K == 0 && src == dst)
            {
                return 0;
            }

            // Build graph based on flights
            var graph = new Dictionary<int, List<Flight>>();    // graph[ [from, [to, price]], [from, [to, price]], [from, [to, price]] ]
            foreach (int[] flight in flights)
            {
                int from = flight[0], to = flight[1], price = flight[2];   // from, to, price: (u,v,w): starts from city u and arrives at v with a price w.
                //graph.PutIfAbsent(from, new ArrayList<>());
                if (!graph.ContainsKey(from))
                    graph.Add(from, new List<Flight>());
                graph[from].Add(new Flight(to, price));
            }

            // memo stores the lowest cumulative price from src to the key city
            var memo = new Dictionary<int,int>();
            memo.Add(src, 0);

            var q = new Queue<CumulativePrice>();
            q.Enqueue(new CumulativePrice(src, 0));

            var stops = -1;
            var cheapest = int.MaxValue;

            while (q.Count > 0)
            {
                var size = q.Count;
                if (stops > K)
                {
                    break;
                }
                for (var i = 0; i < size; i++)
                {
                    var p = q.Dequeue();
                    if (p.city == dst)
                    {
                        cheapest = Math.Min(cheapest, p.cumPrice);
                        continue;
                    }

                    // There is no next stops from p.city, then skip
                    if (!graph.ContainsKey(p.city))
                    {
                        continue;
                    }

                    // Visit all next stops from p.city
                    foreach (var fli in graph[p.city])
                    {
                        var priceNow = p.cumPrice + fli.price;

                        // If memo never stores the cumulative price from src to fli.city
                        // Or the cumulative price stored in memo is more than priceNow
                        // We need to update the cumulative price
                        if (memo.ContainsKey(fli.city) && memo[fli.city] < priceNow)
                        {
                            continue;
                        }
                        memo.Add(fli.city, priceNow);
                        q.Enqueue(new CumulativePrice(fli.city, priceNow));
                    }
                }
                stops++;
            }
            return cheapest == int.MaxValue ? -1 : cheapest;
        }
    }
    public class Flight
    {
        public int city, price;
        public Flight(int city, int price)
        {
            this.city = city;
            this.price = price;
        }
    }

    public class CumulativePrice
    {
        public int city, cumPrice;
        public CumulativePrice(int city, int cumPrice)
        {
            this.city = city;
            this.cumPrice = cumPrice;
        }
    }
}
