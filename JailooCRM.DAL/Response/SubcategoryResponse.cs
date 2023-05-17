using JailooCRM.DAL.Common;
using JailooCRM.DAL.DTOs;

namespace JailooCRM.DAL.Response
{
    public class SubcategoryResponse : Response
    {
        public SubcategoryResponse(int statusCode, string message, bool isSuccess, Subcategory subcategory)
            : base(statusCode, message, isSuccess)
        {
            Name = subcategory.Name;
            Specialization = subcategory.Specialization;
        }

        public string Name { get; set; }
        public Specialization Specialization { get; set; }
    }
}
