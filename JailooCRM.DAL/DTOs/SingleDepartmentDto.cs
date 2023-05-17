using JailooCRM.DAL.Common;

namespace JailooCRM.DAL.DTOs
{
    public class SingleDepartmentDto : EntityDto<int>
    {
        public SingleDepartmentDto(Department entity) : base(entity)
        {
            Name = entity.Name;
        }

        public string Name { get; set; }
    }
}
