using JailooCRM.DAL;
using JailooCRM.DAL.Request;
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
        public async Task<SubcategoryResponse> Create(CreateSubcategoryRequest request)
        {
            Subcategory subcategory = new Subcategory()
            {
                Name = request.Name,
                Specialization = request.Specialization,
                DepartmentId = request.DepartmentId,
            };

            subcategory = await _repository.AddAsync(subcategory);
            
            return new SubcategoryResponse(200, null, true, subcategory);
        }

        [HttpDelete]
        [Route("deleteById")]
        public async Task<Response> Delete(int id)
        {
            _repository.DeleteById(id);

            return new Response(200, null, true);
        }
    
    }
}
