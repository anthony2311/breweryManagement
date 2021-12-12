using Data.Interfaces;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
using System.Linq;
using System.Net;

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
        /// <summary>
        /// Class calculating price for an order with discound depending on the number of beers
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        public OrderQuotationDto OrderQuotation(int id, OrderDto order)
        {
            if (!_wholesalerRepository.Exist(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound, $"Wholesaler with id {id} does not exist");
            }

            // check available beers 
            foreach (var beer in order.Beers)
            {
                if (!_wholesalerStockRepository.Exist(id, beer.BeerId))
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest, $"Beer with id {beer.BeerId} is not sell by wholesaler {id}");
                }
                var currentBeerStock = _wholesalerStockRepository.GetStock(id, beer.BeerId);
                if (currentBeerStock < beer.Quantity)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest, $"The current Wholesaler does not have enough beer {beer.BeerId} in stock. The current stock for this beer is {currentBeerStock}");
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
