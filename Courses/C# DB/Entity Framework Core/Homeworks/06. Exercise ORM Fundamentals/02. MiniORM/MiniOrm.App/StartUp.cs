using System;
using MiniOrm.App.Data;

namespace MiniOrm.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            const string connectionString = @"Server = DESKTOP - TU655AE\SQLEXPRESS; Database = MiniORM; Integrated Security = True";
            var context = new SoftUniDbContext(connectionString);

            var employees = context.Employees.ToList();
        }
    }
}
