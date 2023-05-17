using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JailooCRM.DAL.Common;

namespace JailooCRM.DAL.Response
{
    public class DepartmentsResponse
    {
        public T Id { get; set; }
        public string DateTimeAdded { get; set; }
        public string DateTimeUpdated { get; set; }
    }
}
