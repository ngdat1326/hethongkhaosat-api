namespace api.DTOs
{
    public class VerifyOtpDto
    {
        public string Username { get; set; } = null!;
        public string OtpCode { get; set; } = null!;
    }
}
