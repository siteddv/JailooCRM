using JailooCRM.DAL.Common;

namespace JailooCRM.DAL
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public decimal PricePerPortion { get; set; }
        public int Count { get; set; }
        public bool IsAvailiable => Count > 0;
        public double Portion
        {
            get
            {
                if (TypeOfPortion == TypeOfPortion.ByOne)
                    return 1;

                return _portion;
            }
            set
            {
                if (TypeOfPortion == TypeOfPortion.ByOne)
                {
                    _portion = 1;
                    return;
                }

                _portion = value;
            }
        }
        private double _portion;

        public TypeOfPortion TypeOfPortion { get; set; }

        public int? SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        
        
    }
}
