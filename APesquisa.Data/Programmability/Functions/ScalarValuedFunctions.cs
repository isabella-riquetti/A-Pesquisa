using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;


namespace APesquisa.Data.Programmability.Functions
{
    public class ScalarValuedFunctions
    {
        private readonly DbContext _dbContext;
        public ScalarValuedFunctions(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
