using JailooCRM.BLL;
using JailooCRM.DAL;
using JailooCRM.DAL.Request;
using JailooCRM.DAL.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JailooCRM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IRepository<Department, int> _repository;
        private readonly DepartmentService _service;
        private readonly ILogger _logger;

        public DepartmentController(IRepository<Department, int> departmentRepository, 
            DepartmentService service,
            ILogger<DepartmentController> logger)
        {
            _repository = departmentRepository;
            _service = service;
            _logger = logger;
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
        [Route("GetById")]
        public async Task<DepartmentResponse> GetById(int id)
        {
            _logger.LogError("Error occurred");
            Department department = await _service.GetByIdAsync(id);

            return new DepartmentResponse(200, null, true, department);
        }

        [HttpGet]
        [Route("Search")]
        public async Task<ListDepartmentsResponse> Search([FromQuery] DepartmentFilterRequest? requst)
        {
            _logger.LogInformation("Poshel nahui");
            var result = await _service.Search(requst);
            return new ListDepartmentsResponse(200, "Success", true, result);
        }
    }
}
