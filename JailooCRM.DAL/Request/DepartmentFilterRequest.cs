namespace JailooCRM.DAL.Request
{
    public class DepartmentFilterRequest
    {
        public string? Search { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
