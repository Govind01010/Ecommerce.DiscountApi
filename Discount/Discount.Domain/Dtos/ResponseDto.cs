namespace Discount.Domain.Dtos
{
    public class ResponseDto
    {
        public object? result { get; set; }
        public bool isSuccess { get; set; } = true;
        public string message { get; set; } = "";
    }
}
