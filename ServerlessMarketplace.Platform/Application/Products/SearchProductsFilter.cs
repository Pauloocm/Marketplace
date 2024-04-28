namespace ServerlessMarketplace.Platform.Application.Products
{
    public class SearchProductsFilter
    {
        public string? Term { get; set; }
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; }
        public int Page {  get; set; }
        public int PageSize { get; set; }
    }
}
