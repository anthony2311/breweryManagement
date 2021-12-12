using Data.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class WholesalerOrderService : IWholesalerOrderService
    {
        private IWholesalerRepository _wholesalerRepository;
        private IWholesalerStockRepository _wholesalerStockRepository;
        private IBeerRepository _beerRepository;

        private static readonly double TenBeersDiscount = 0.1;
        private static readonly double TwentyBeersDiscount = 0.2;

        public WholesalerOrderService(IWholesalerRepository wholesalerRepository,IWholesalerStockRepository wholesalerStockRepository, IBeerRepository beerRepository)
        {
            _wholesalerRepository = wholesalerRepository;
            _wholesalerStockRepository = wholesalerStockRepository;
            _beerRepository = beerRepository;
        }
        public OrderQuotationDto OrderQuotation(int id, OrderDto order)
        {
            if (!_wholesalerRepository.Exist(id))
            {
                throw new KeyNotFoundException($"Wholesaler with id {id} does not exist");
            }

            // check available beers 
            foreach (var beer in order.Beers)
            {
                if (!_wholesalerStockRepository.Exist(id, beer.BeerId))
                {
                    throw new ArgumentException($"Beer with id {beer.BeerId} is not sell by wholesaler {id}");
                }
                var currentBeerStock = _wholesalerStockRepository.GetStock(id, beer.BeerId);
                if (currentBeerStock < beer.Quantity)
                {
                    throw new ArgumentException($"The current Wholesaler does not have enough beer {beer.BeerId} in stock. The current stock for this beer is {currentBeerStock}");
                }
            }

            var response = new OrderQuotationDto();
            response.Beers = order.Beers;
            response.Price = CalculateOrderPrice(order);
            return response;
        }

        private double CalculateOrderPrice(OrderDto order)
        {
            // calculate total price
            double totalPrice = 0;
            foreach (var beer in order.Beers)
            {
                var currentBeerPrice = _beerRepository.GetBeerPrice(beer.BeerId);
                totalPrice += currentBeerPrice * beer.Quantity;
            }
            
            // calculate discount
            double discount = 0;
            int totalQuantity = order.Beers.Sum(b => b.Quantity);
            if(totalQuantity > 20)
            {
                discount = TwentyBeersDiscount;
            }
            else if(totalQuantity > 10)
            {
                discount = TenBeersDiscount;
            }

            // apply discount
            totalPrice -= totalPrice * discount;

            return totalPrice;
        }
    }
}
