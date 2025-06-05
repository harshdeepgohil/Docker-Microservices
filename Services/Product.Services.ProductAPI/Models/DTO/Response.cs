namespace Product.Services.ProductAPI.Models.DTO
{
    public class Response
    {
        public object? response {  get; set; }
        public bool IsSuccess {  get; set; }

        public string? Message {  get; set; }
    }
}
