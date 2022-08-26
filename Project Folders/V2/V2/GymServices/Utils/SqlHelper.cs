using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace GymServices
{
    public class SqlHelper
    {
        public string ConnectionString { get; set; }

        public SqlHelper(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        public string ExecuteStoredProcured(string ProcName)
        {
            List<Dictionary<string, dynamic>> resultList = new List<Dictionary<string, dynamic>>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(ProcName, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    var t = new Dictionary<string, dynamic>();
                    for (var i = 0; i < sdr.FieldCount; i++)
                    {
                        t[sdr.GetName(i)] = sdr[i];
                    }
                    resultList.Add(t);
                }
            }
            string output = JsonConvert.SerializeObject(resultList);
            return output;
        }

        public string ExecuteInLineSql(string Query)
        {
            List<Dictionary<string, dynamic>> resultList = new List<Dictionary<string, dynamic>>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(Query, connection)
                {
                    CommandType = CommandType.Text
                };

                connection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    var t = new Dictionary<string, dynamic>();
                    for (var i = 0; i < sdr.FieldCount; i++)
                    {
                        t[sdr.GetName(i)] = sdr[i];
                    }
                    resultList.Add(t);
                }
            }
            string output = JsonConvert.SerializeObject(resultList);
            return output;
        }
    }
}