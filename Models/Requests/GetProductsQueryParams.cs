using Microsoft.AspNetCore.Mvc;

namespace eShop_Backend.Models.Requests
{
    public class GetProductsQueryParams
    {
        [FromQuery]
        public int? categoryId { get; set; }

        [FromQuery]
        public int page { get; set; } = 0;

        [FromQuery]
        public int limit { get; set; } = 10;
    }
}
