using JailooCRM.DAL.Common;

namespace JailooCRM.DAL.DTOs
{
    public class SingleSubCategoryDto
    {
        public SingleSubCategoryDto(Subcategory entity)
        {
            Name = entity.Name;
            Specialization = entity.Specialization;
        }

        public string Name { get; set; }
        public Specialization Specialization { get; set; }
    }
}
