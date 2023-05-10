using JailooCRM.DAL;
using JailooCRM.DAL.Response;
using Microsoft.AspNetCore.Mvc;

namespace JailooCRM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IRepository<Department, int> _departmentRepository;

        public DepartmentController(IRepository<Department, int> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpPost]
        [Route("create")]
        public async Task<DepartmentResponse> CreateDepartment([FromBody] string depName)
        {
            Department department = new Department()
            {
                Name = depName,
            };

            department = await _departmentRepository.AddAsync(department);

            return new DepartmentResponse(200, null, true, department);
        }
    }
}
