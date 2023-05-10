using JailooCRM.DAL;
using JailooCRM.DAL.Response;
using Microsoft.AspNetCore.Mvc;

namespace JailooCRM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubcategoryController : ControllerBase
    {
        private readonly IRepository<Subcategory, int> _repository;

        public SubcategoryController(IRepository<Subcategory, int> subcategoryRepository)
        {
            _repository = subcategoryRepository;
        }

        [HttpPost]
        [Route("create")]
        public async Task<SubcategoryResponse> CreateSubcategory(CreateSubcategoryRequest request)
        {
            Subcategory subcategory = new Subcategory()
            {
                Name = request.Name,
                Specialization = request.Specialization,
                DepartmentId = request.DepartmentId,
            };

            subcategory = await _repository.AddAsync(subcategory);
            
            return new SubcategoryResponse(subcategory, 200, null, true);
        }
    }
}
