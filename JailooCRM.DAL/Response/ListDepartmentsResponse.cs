using JailooCRM.DAL.DTOs;

namespace JailooCRM.DAL.Response
{
    public class ListDepartmentsResponse : Response
    {
        public ListDepartmentsResponse(int statusCode, string message, bool isSuccess, List<Department> departments) 
            : base(statusCode, message, isSuccess)
        {
            Departments = departments.Select(dep => new SingleDepartmentDto(dep)).ToList();
        }

        public List<SingleDepartmentDto> Departments { get; set; }
    }
}
