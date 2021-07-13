using System;
using System.Collections.Generic;

namespace BestBuyBestPractices
{
    public interface IDepartmentRepository
    {
        // Implemented in DapperDepartmentRepository class
        IEnumerable<Department> GetAllDepartments();
    }
}
