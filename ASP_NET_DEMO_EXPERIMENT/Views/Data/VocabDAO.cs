using ASP_NET_DEMO_EXPERIMENT.Models;
using System.Data.SqlClient;

namespace ASP_NET_DEMO_EXPERIMENT.Views.Data
{
    internal class VocabDAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<VocabViewModel> FetchAll()
        {
            List<VocabViewModel> returnList = new List<VocabViewModel>();

            using (SqlConnection connetion = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Vocabs";

                SqlCommand command = new SqlCommand(sqlQuery, connetion);

                connetion.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        VocabViewModel vocab = new VocabViewModel();
                        vocab.Id = reader.GetInt32(0);
                        vocab.Word = reader.GetString(1);
                        vocab.Definition = reader.GetString(2);

                        returnList.Add(vocab);
                    }
                }

            }
            return returnList;
        }
    }
}