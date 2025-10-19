using _15PC_BloomBakery.DTOs.OrderDTOs;
using _15PC_BloomBakery.Services.OrderServices;
using _15PC_BloomBakery.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _15PC_BloomBakery.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public OrderController(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }

        // Listeleme
        public async Task<IActionResult> Index(string searchString, int page = 1, int pageSize = 10)
        {
            ViewBag.pageTitle = "Sipariş Bilgileri";
            ViewBag.SearchString = searchString;
            ViewBag.PageSize = pageSize;

            var orders = await _orderService.GetAllOrderAsync();

            // Arama işlemi
            if (!string.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(o =>
                    o.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    o.Surname.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    o.ProductName.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }

            // Paging işlemi
            int totalItems = orders.Count;
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            orders = orders
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(orders);
        }        

        // Yeni Ekleme Sayfası (GET)
        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            ViewBag.pageTitle = "Yeni Sipariş Ekle";

            //Ürünleri Getirme
            var products = await _productService.GetAllProductsAsync();
            ViewBag.ProductList = products.Select(c => new SelectListItem
            {
                Text = c.ProductName,
                Value = c.ProductId.ToString()
            }).ToList();

            return View();
        }

        // Yeni Ekleme İşlemi (POST)
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {          
            if (!ModelState.IsValid)
                return View(createOrderDto);

            await _orderService.CreateOrderAsync(createOrderDto);
            return RedirectToAction(nameof(Index));
        }

        // Güncelleme Sayfası (GET)
        [HttpGet]
        public async Task<IActionResult> UpdateOrder(int id)
        {
            //Ürünleri Getirme
            var products = await _productService.GetAllProductsAsync();
            ViewBag.ProductList = products.Select(c => new SelectListItem
            {
                Text = c.ProductName,
                Value = c.ProductId.ToString()
            }).ToList();

            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();

            ViewBag.pageTitle = "Sipariş Güncelle";
            return View(order);
        }

        // Güncelleme İşlemi (POST)
        [HttpPost]
        public async Task<IActionResult> UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            if (!ModelState.IsValid)
                return View(updateOrderDto);

            await _orderService.UpdateOrderAsync(updateOrderDto);
            return RedirectToAction(nameof(Index));
        }

        // Silme İşlemi
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
