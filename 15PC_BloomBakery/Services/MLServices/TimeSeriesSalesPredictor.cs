using _15PC_BloomBakery.DTOs.MLDTOs;
using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;

namespace _15PC_BloomBakery.Services.MLServices
{
    public class TimeSeriesSalesPredictor
    {
        private readonly MLContext _mlContext;

        public TimeSeriesSalesPredictor()
        {
            _mlContext = new MLContext();
        }

        public OrderForecast PredictNext3Months(List<float> monthlySales)
        {
            if (monthlySales.Count < 4)
                throw new Exception("Yeterli veri yok. En az 4 aylık veri olmalı.");

            var data = monthlySales.Select(x => new OrderData { TotalAmount = x }).ToList();
            var dataView = _mlContext.Data.LoadFromEnumerable(data);

            var pipeline = _mlContext.Forecasting.ForecastBySsa(
                outputColumnName: nameof(OrderForecast.ForecastedAmounts),
                inputColumnName: nameof(OrderData.TotalAmount),
                windowSize: 3,
                seriesLength: data.Count,
                trainSize: data.Count,
                horizon: 3,
                confidenceLevel: 0.95f,
                confidenceLowerBoundColumn: nameof(OrderForecast.LowerBoundedForecast),
                confidenceUpperBoundColumn: nameof(OrderForecast.UpperBoundedForecast)
            );

            var model = pipeline.Fit(dataView);
            var engine = model.CreateTimeSeriesEngine<OrderData, OrderForecast>(_mlContext);

            var forecast = engine.Predict();
            return forecast;
        }
    }
}
