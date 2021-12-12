using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    /// <summary>
    /// Class containing multiple static list of datas for seed or mock database
    /// </summary>
    public static class DataSample
    {
        public static List<Wholesaler> GetWholesalers()
        {
            return new List<Wholesaler>() {
                new Wholesaler()
                {
                    Id = 1,
                    Name = "GeneDrinks"
                },
                new Wholesaler()
                {
                    Id = 2,
                    Name = "Delneste"
                },
                new Wholesaler()
                {
                    Id = 3,
                    Name = "CORMAN COLLINS"
                }
            };
        }
        public static List<Brewery> GetBreweries()
        {
            return new List<Brewery>() {
                new Brewery()
                {
                    Id = 1,
                    Name = "Abbaye de Leffe"
                },
                new Brewery()
                {
                    Id = 2,
                    Name = "Abbaye de Chimay"
                },
                new Brewery()
                {
                    Id = 3,
                    Name = "Abbaye de Floreffe"
                },
            };
        }
        public static List<Beer> GetBeers()
        {
            return new List<Beer>() {
                new Beer()
                {
                    Id = 1,
                    Name = "Leffe Blonde",
                    AlcoholDegree = 6.6,
                    Price = 2.20,
                    BreweryId = 1
                },
                new Beer()
                {
                    Id = 2,
                    Name = "Leffe Triple",
                    AlcoholDegree = 8.5,
                    Price = 3.50,
                    BreweryId = 1
                },
                new Beer()
                {
                    Id = 3,
                    Name = "Chimay bleue",
                    AlcoholDegree = 9,
                    Price = 2.40,
                    BreweryId = 2
                },
                new Beer()
                {
                    Id = 4,
                    Name = "Floreffe Blonde",
                    AlcoholDegree = 6.5,
                    Price = 2.70,
                    BreweryId = 3
                },
                new Beer()
                {
                    Id = 5,
                    Name = "Floreffe Blanche",
                    AlcoholDegree = 4.5,
                    Price = 3.40,
                    BreweryId = 3
                }
            };
        }
        public static List<WholesalerStock> GetWholesalerStocks()
        {
            return new List<WholesalerStock>() {
                new WholesalerStock()
                {
                    WholesalerId = 1,
                    BeerId = 1,
                    quantity = 50
                },
                new WholesalerStock()
                {
                    WholesalerId = 1,
                    BeerId = 2,
                    quantity = 3
                },
                new WholesalerStock()
                {
                    WholesalerId = 2,
                    BeerId = 3,
                    quantity = 10
                },
                new WholesalerStock()
                {
                    WholesalerId = 3,
                    BeerId = 3,
                    quantity = 100
                },
                new WholesalerStock()
                {
                    WholesalerId = 3,
                    BeerId = 4,
                    quantity = 20
                },
                new WholesalerStock()
                {
                    WholesalerId = 3,
                    BeerId = 5,
                    quantity = 78
                }
            };
        }
    }
}
