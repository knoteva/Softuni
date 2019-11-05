using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Problem
{
    class Procedure
    {
        public const string CreateProcedure = @"CREATE PROC usp_GetOlder @id INT
                                                AS
                                                UPDATE Minions
                                                   SET Age += 1
                                                 WHERE Id = @id";

        public const string SelectMinionQuery = "SELECT Name, Age FROM Minions WHERE Id = @Id";
    }
}
