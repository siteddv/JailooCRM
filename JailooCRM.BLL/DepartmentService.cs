﻿using JailooCRM.DAL;
using JailooCRM.DAL.Request;
using JailooCRM.DAL.Response;

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
    }
}