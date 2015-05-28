using System;
using System.Data.SqlClient;
using RCRunner;

namespace TestExecution
{
    public class TestExecution : ITestExecution
    {
        public void AfterTestExecution(string idTestCase)
        {
            var sql = @"UPDATE ContasTeste SET IsUsando = 0, IdTestCase = null, DataHoraAlocacao = null WHERE idTestCase = '" + idTestCase + @"';";
            var myConnection = new SqlConnection(@"Server=10.20.15.81\sql2012;Database=NOVAJUS_MAIN_QA;Trusted_Connection=Yes;");
            ExecutaQuery(sql, myConnection);
        }

        private static void ExecutaQuery(string sql, SqlConnection conexao)
        {
            var myCommand = new SqlCommand(sql, conexao);
            try
            {
                conexao.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
