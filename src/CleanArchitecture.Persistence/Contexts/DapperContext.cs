using Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Persistence.Context
{
    public class DapperContext
    {

        private readonly ConnectionStringsSetting _connectionString;
        public SqlConnection connection;

        public DapperContext(IOptions<ConnectionStringsSetting> connectionString)
        {
            _connectionString = connectionString.Value;
            connection = new SqlConnection(_connectionString.DefaultConnection);
        }

    }
}
