using JailooCRM.DAL.DTOs;

namespace JailooCRM.DAL.Response
{
    public class DepartmentResponse : Response
    {
        public DepartmentResponse(int statusCode, string message, bool isSuccess, Department department)
            : base(statusCode, message, isSuccess)
        {
            Department = new SingleDepartmentDto(department);
        }

        public SingleDepartmentDto Department { get; set; }
    }
}
