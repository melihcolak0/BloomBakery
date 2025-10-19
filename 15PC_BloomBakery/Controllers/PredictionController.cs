using _15PC_BloomBakery.Context;
using _15PC_BloomBakery.Services.MLServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _15PC_BloomBakery.Controllers
{
    public class PredictionController : Controller
    {
        private readonly AppDbContext _context;
        private readonly TimeSeriesSalesPredictor _predictor;

        public PredictionController(AppDbContext context)
        {
            _context = context;
            _predictor = new TimeSeriesSalesPredictor();
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.pageTitle = "ML ile Sipariş Tahminlemesi";

            var productSales = await _context.Orders
                .Where(o => o.OrderDate.Year == 2025 && o.OrderDate.Month <= 9)
                .GroupBy(o => new { o.ProductId, o.Product.ProductName, Month = o.OrderDate.Month })
                .Select(g => new
                {
                    g.Key.ProductId,
                    g.Key.ProductName,
                    g.Key.Month,
                    TotalAmount = g.Sum(x => x.Amount)
                })
                .OrderBy(x => x.ProductId)
                .ThenBy(x => x.Month)
                .ToListAsync();

            var productPredictions = new List<dynamic>();

            foreach (var group in productSales.GroupBy(x => new { x.ProductId, x.ProductName }))
            {
                var monthlySales = group.OrderBy(x => x.Month)
                                        .Select(x => (float)x.TotalAmount)
                                        .ToList();

                var forecast = _predictor.PredictNext3Months(monthlySales);

                productPredictions.Add(new
                {
                    group.Key.ProductName,
                    JanToSep = monthlySales.Sum(),
                    Oct = forecast.ForecastedAmounts[0],
                    Nov = forecast.ForecastedAmounts[1],
                    Dec = forecast.ForecastedAmounts[2],
                    OctLower = forecast.LowerBoundedForecast[0],
                    OctUpper = forecast.UpperBoundedForecast[0],
                    YearTotal = monthlySales.Sum() + forecast.ForecastedAmounts.Sum()
                });
            }

            return View(productPredictions);
        }
    }
}
