namespace AML.Server.DTOs
{
    public class UpdateDetailsRequest
    {
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
