using JailooCRM.DAL;
using JailooCRM.DAL.Request;
using JailooCRM.DAL.Response;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JailooCRM.BLL
{
    public class DepartmentService
    {
        private readonly IRepository<Department, int> _repository;

        public DepartmentService(IRepository<Department, int> departmentRepository)
        {
            _repository = departmentRepository;
        }

        public async Task<Response> Update(UpdateDepartmentRequest request)
        {
            Department department = await _repository.GetByIdAsync(request.Id);
            department.Name = request.Name;
            _repository.Update(department);

            return new Response(200, null, true);
        }
        public async Task<List<Department>> GetAll()
        {
             return  await _repository.GetAllAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        
        public async Task<List<Department>> Search(DepartmentFilterRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Search))
            {
                return await GetAll();
            }

            request.Search = request.Search.ToLower().Trim();

            var baseResult = await _repository.GetQuery()
                    .AsNoTracking()
                    .Where(obj => obj.Name.ToLower().Contains(request.Search))
                    .ToListAsync();

            if (request.PageSize == null || request.PageNumber == null)
            {
                return baseResult;
            }

            return baseResult
                .Skip((request.PageNumber.Value - 1) * request.PageSize.Value)
                .Take(request.PageSize.Value).ToList();
        }
    }
}