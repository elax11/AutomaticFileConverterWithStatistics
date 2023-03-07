namespace FileProcessor
{
    public interface ITransformed
    {
        string City { get; set; }
        IEnumerable<Service> Services { get; set; }
        decimal Total { get; set; }
    }
}
