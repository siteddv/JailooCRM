namespace JailooCRM.DAL.Response
{
    public class DepartmentResponse : EntityResponse<int>
    {
        public DepartmentResponse(int statusCode, string message, bool isSuccess, Department department)
            : base(department, statusCode, message, isSuccess)
        {
            Name = department.Name;
        }

        public string Name { get; set; }
    }
}
