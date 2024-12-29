using Microsoft.AspNetCore.SignalR;
using OrderManagement.Business.Abstract;

namespace OrderManagement.API.Hubs
{
    public class SignalRHub(ICategoryService _categoryService, IProductService _productService, IOrderService _orderService, ICashBoxService _cashBoxService, IRestaurantTableService _restaurantTableService, IBookingService _bookingService, INotificationService _notificationService, IRestaurantTableService _tableService) : Hub
    {
        private static int clientCount { get; set; } = 0;

        public async Task SendStatistics()
        {
            var categoryCount = _categoryService.TCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);

            var productCount = _productService.TCount();
            await Clients.All.SendAsync("ReceiveProductCount", productCount);

            var activeCategories = _categoryService.TFilteredCount(x => x.Status == true);
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategories);

            var passiveCategories = _categoryService.TFilteredCount(x => x.Status == false);
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategories);

            var hamburgerCount = _productService.TFilteredCount(x => x.Category.CategoryName.ToLower() == "hamburger");
            await Clients.All.SendAsync("ReceiveHamburgerCount", hamburgerCount);

            var drinkCount = _productService.TFilteredCount(x => x.Category.CategoryName.ToLower() == "içecek");
            await Clients.All.SendAsync("ReceiveDrinkCount", drinkCount);

            var avgProductPrice = _productService.TAvgProductPrice();
            await Clients.All.SendAsync("ReceiveAvgProductPrice", avgProductPrice.ToString("00.00") + " ₺");

            var expensiveProduct = _productService.TMostExpensiveProduct();
            await Clients.All.SendAsync("ReceiveExpensiveProduct", expensiveProduct);

            var cheapestProduct = _productService.TCheapestProduct();
            await Clients.All.SendAsync("ReceiveCheapestProduct", cheapestProduct);

            var avgHamburgerPrice = _productService.TAvgHamburgerPrice();
            await Clients.All.SendAsync("ReceiveAvgHamburgerPrice", avgHamburgerPrice.ToString("00.00") + " ₺");

            await Clients.All.SendAsync("ReceiveAvgHamburgerPrice", avgHamburgerPrice.ToString("00.00") + " ₺");
            var totalOrderCount = _orderService.TCount();

            var orderCount = _orderService.TCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", orderCount);

            var activeOrders = _orderService.TFilteredCount(x => x.Description == "Müşteri Masada");
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrders);

            var lastOrderPrice = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", lastOrderPrice.ToString("00.00") + " ₺");

            var totalCash = _cashBoxService.TTotalCashBox();
            await Clients.All.SendAsync("ReceiveTotalCash", totalCash.ToString("00.00") + " ₺");

            var todaysTotalPrice = _orderService.TTodaysTotalPrice();
            await Clients.All.SendAsync("ReceiveTodaysTotalPrice", todaysTotalPrice.ToString("00.00") + " ₺");

            var totalTableCount = _restaurantTableService.TCount();
            await Clients.All.SendAsync("ReceiveTotalTableCount", totalTableCount);
        }

        public async Task SendProgress()
        {
            var totalCash = _cashBoxService.TTotalCashBox();
            await Clients.All.SendAsync("ReceiveTotalCash", totalCash.ToString("00.00") + " ₺");

            var activeOrders = _orderService.TFilteredCount(x => x.Description == "Müşteri Masada");
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrders);

            var totalTableCount = _restaurantTableService.TCount();
            await Clients.All.SendAsync("ReceiveTotalTableCount", totalTableCount);

            var avgPriceValue = _productService.TAvgProductPrice();
            await Clients.All.SendAsync("ReceiveAvgPriceValue", avgPriceValue.ToString("00"));

            var hamburgerCount = _productService.TFilteredCount(x => x.Category.CategoryName.ToLower() == "hamburger");
            await Clients.All.SendAsync("ReceiveHamburgerCount", hamburgerCount);

            var drinkCount = _productService.TFilteredCount(x => x.Category.CategoryName.ToLower() == "içecek");
            await Clients.All.SendAsync("ReceiveDrinkCount", drinkCount);

            var avgHamburgerPrice = _productService.TAvgHamburgerPrice();
            await Clients.All.SendAsync("ReceiveAvgHamburgerPrice", avgHamburgerPrice.ToString("00"));
        }

        public async Task GetBookingList()
        {
            var values = _bookingService.TGetList();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }

        public async Task SendNotifications()
        {
            var unreadNotifications = _notificationService.TUnreadNotificationCount();
            await Clients.All.SendAsync("ReceiveUnreadNotifications", unreadNotifications);

            var unreadNotificationList = _notificationService.TGetFilteredList(x => x.Status == false);
            await Clients.All.SendAsync("ReceiveUnreadNotificationList", unreadNotificationList);
        }

        public async Task GetTableStatus()
        {
            var table = _tableService.TGetList();
            await Clients.All.SendAsync("ReceiveTableStatus", table);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }

    }
}