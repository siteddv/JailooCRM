using JailooCRM.BLL;
using JailooCRM.DAL;
using JailooCRM.DAL.Request;
using JailooCRM.DAL.Response;
using Microsoft.AspNetCore.Mvc;

namespace JailooCRM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IRepository<Department, int> _repository;
        private readonly DepartmentService _service;

        public DepartmentController(IRepository<Department, int> departmentRepository, DepartmentService service)
        {
            _repository = departmentRepository;
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        public async Task<DepartmentResponse> Create([FromBody] string depName)
        {
            Department department = new Department()
            {
                Name = depName,
            };

            department = await _repository.AddAsync(department);

            return new DepartmentResponse(200, null, true, department);
        }

        [HttpDelete]
        [Route("deleteById")]
        public async Task<Response> Delete(int id)
        {
            _repository.DeleteById(id);

            return new Response(200, null, true);
        }

        [HttpPut]
        [Route("update")]
        public async Task<Response> Update(UpdateDepartmentRequest request)
        {
            return await _service.Update(request);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<List<Department>> GetResponseAsync()
        {
           return await _service.GetAll();
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<Department> GetById(int id)
        {
            return await _service.GetByIdAsync(id);
        }
        
    }
}
