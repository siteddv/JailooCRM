namespace JailooCRM.DAL
{
    public class DepartmentResponse : Response
    {
        public Department Department { get; set; }
        public DepartmentResponse(int statusCode, string message, bool isSuccess, Department department) 
            : base(statusCode, message, isSuccess)
        {
            Department = department;
        }
    }
}
