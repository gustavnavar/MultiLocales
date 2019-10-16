using MultiLocales.Models;
using MultiLocales.Repostories;
using GridMvc.Server;
using GridShared;
using GridShared.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;

namespace MultiLocales.Services
{
    public class OrderService : IOrderService
    {

        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderVM> _orderVmRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<OrderVM> orderVmRepository)
        {
            _orderRepository = orderRepository;
            _orderVmRepository = orderVmRepository;
        }

        public ItemsDTO<Order> GetOrdersGridRows(Action<IGridColumnCollection<Order>> columns,
            QueryDictionary<StringValues> query)
        {
            var server = new GridServer<Order>(_orderRepository.All, new QueryCollection(query),
                true, "ordersGrid", columns, 10)
                    .Sortable()
                    .Filterable()
                    .WithMultipleFilters()
                    .Searchable(true, false);

            // return items to displays
            var items = server.ItemsToDisplay;

            // uncomment the following lines are to test null responses
            //items = null;
            //items.Items = null;
            //items.Pager = null;
            return items;
        }

        public ItemsDTO<OrderVM> GetOrdersGridRows(Action<IGridColumnCollection<OrderVM>> columns,
            QueryDictionary<StringValues> query)
        {
            var server = new GridServer<OrderVM>(_orderVmRepository.All, new QueryCollection(query), true,
                "ordersGrid", columns, 10)
                    .Sortable()
                    .Filterable()
                    .WithMultipleFilters()
                    .Searchable(true, false);

            // return items to displays
            var items = server.ItemsToDisplay;
            return items;
        }
    }

    public interface IOrderService
    {
        ItemsDTO<Order> GetOrdersGridRows(Action<IGridColumnCollection<Order>> columns, QueryDictionary<StringValues> query);
        ItemsDTO<OrderVM> GetOrdersGridRows(Action<IGridColumnCollection<OrderVM>> columns, QueryDictionary<StringValues> query);
    }
}
