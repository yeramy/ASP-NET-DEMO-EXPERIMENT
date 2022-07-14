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

        public VocabViewModel FetchOne(int id)
        {
            VocabViewModel returnList = new VocabViewModel();

            using (SqlConnection connetion = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Vocabs WHERE Id = @Id";

                SqlCommand command = new SqlCommand(sqlQuery, connetion);

                connetion.Open();

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int, 1000).Value = id;

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        returnList.Id = reader.GetInt32(0);
                        returnList.Word = reader.GetString(1);
                        returnList.Definition = reader.GetString(2);
                    }
                }

            }
            return returnList;
        }

        public int CreateRow(VocabViewModel vocabEntry)
        {
            List<VocabViewModel> returnList = new List<VocabViewModel>();
            int newID = -1;
            using (SqlConnection connetion = new SqlConnection(connectionString))
            {
                string sqlQuery = "INSERT INTO dbo.Vocabs VALUES((SELECT MAX(Id)+1 FROM dbo.Vocabs),@Word, @Definition)";

                SqlCommand command = new SqlCommand(sqlQuery, connetion);
                connetion.Open();

                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = vocabEntry.Word;
                command.Parameters.Add("@Word", System.Data.SqlDbType.VarChar, 1000).Value = vocabEntry.Word;
                command.Parameters.Add("@Definition", System.Data.SqlDbType.VarChar, 1000).Value = vocabEntry.Definition;

                

                command.ExecuteNonQuery();

            }
            return newID;
        }

        public void ModifyRow(VocabViewModel target)
        {
            using (SqlConnection connetion = new SqlConnection(connectionString))
            {
                string sqlQuery = "UPDATE dbo.Vocabs SET Word = @Word, Definition = @Definition WHERE Id = @Id" ;

                SqlCommand command = new SqlCommand(sqlQuery, connetion);
                connetion.Open();

                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = target.Id;
                command.Parameters.Add("@Word", System.Data.SqlDbType.VarChar, 1000).Value = target.Word;
                command.Parameters.Add("@Definition", System.Data.SqlDbType.VarChar, 1000).Value = target.Definition;



                command.ExecuteNonQuery();

            }

        }
    }
}