using System;
using System.Collections.Generic;
using System.Text;
using MiniOrm.App.Data.Entities;

namespace MiniOrm.App.Data
{
    using MiniORM;
    public class SoftUniDbContext: DbContext
    {
        public SoftUniDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Employee> Employees { get; }

        public DbSet<Project> Projects { get; }

        public DbSet<Department> Departments { get; }

        public DbSet<EmployeeProject> EmployeesProjects { get; }
    }
}
