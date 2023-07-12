using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using Library.Config.Dto.Response;

namespace Library.Config
{
    public class DbClass
    {
        private String _connection;
        public DbClass() {
            this._connection = "Server=MSI;Database=biblioteca;Trusted_Connection=True;";
        }

        public DbResultDto executeQuery(Object pObject) {

            DbResultDto result=new DbResultDto();
            try {
                SqlConnection connection = new SqlConnection(this._connection);
                
                    connection.Open();
                SqlCommand command = new SqlCommand(pObject.GetType().Name, connection);
                        command.CommandType = CommandType.StoredProcedure;
                        Type type = pObject.GetType();
                        PropertyInfo[] ps = type.GetProperties();
                        

                        foreach (PropertyInfo p in ps)
                        {
                            command.Parameters.AddWithValue(p.Name, p.GetValue(pObject));
                        }

                        SqlDataReader rs = command.ExecuteReader();
                        

                        result.Data = rs;
                        result.Success = true;

                    
                
            }

            catch {
                result.Success = false;
                result.Data = null;
            }
            return result;
            
            
        }


    }
}
