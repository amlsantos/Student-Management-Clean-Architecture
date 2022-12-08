namespace Api.Students.Requests;

public record StudentTransferRequest
{
    public string Course { get; set; }
    public string Grade { get; set; }
}