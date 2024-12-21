namespace DigiBite_Core.Helpers
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalRecords { get; set; }
    }
}
