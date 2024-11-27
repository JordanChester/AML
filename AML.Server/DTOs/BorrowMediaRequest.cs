namespace AML.Server.DTOs;

public class BorrowMediaRequest
{
    public int AccountId { get; set; }
    public int MediaId { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}