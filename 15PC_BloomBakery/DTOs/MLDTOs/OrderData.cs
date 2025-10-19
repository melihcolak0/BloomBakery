using Microsoft.ML.Data;

namespace _15PC_BloomBakery.DTOs.MLDTOs
{
    public class OrderData
    {
        public float TotalAmount { get; set; }
    }

    public class OrderForecast
    {
        [VectorType(3)] // 3 aylık tahmin (Ekim, Kasım, Aralık)
        public float[] ForecastedAmounts { get; set; }

        [VectorType(3)]
        public float[] LowerBoundedForecast { get; set; }

        [VectorType(3)]
        public float[] UpperBoundedForecast { get; set; }
    }
}
