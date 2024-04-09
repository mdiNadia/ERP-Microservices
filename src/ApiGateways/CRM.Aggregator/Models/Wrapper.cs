namespace CRM.Aggregator.Models
{
    public class Wrapper<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string FirstPage { get; set; }
        public string LastPage { get; set; }

        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public string? NextPage { get; set; }
        public string? PreviousPage { get; set; }
        public List<T> Data {  get; set; }
        public bool Succeeded { get; set; }
        public string Errors { get; set; }
        public string Message { get; set; }
  
    }
}
