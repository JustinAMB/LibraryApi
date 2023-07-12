using System.Data.SqlClient;

namespace Library.Config.Dto.Response
{
    public class DbResultDto
    {
        public bool Success { get; set; }
        public SqlDataReader? Data { get; set; }
        public DbResultDto() {
            Success = false;
            Data = null;
        }
    }
}
