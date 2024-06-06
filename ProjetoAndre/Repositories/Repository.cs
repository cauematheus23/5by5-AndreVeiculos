using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Configuration;
// insert cliente with dapper
namespace Repositories
{
    public class Repository : IRepository
    {
         private string Conn { get; set; }
        public Repository()
        {
            Conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }
        public void ClientInsert(Client client)
        {
            var IdAdress = 0;
            var cpf = String.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(Conn))
                {
                    connection.Open();
                    var transaction = connection.BeginTransaction();
                    IdAdress = connection.ExecuteScalar<int>("INSERT INTO TB_ADRESS (Street,ZipCode,Complement,State,Neighborhood,City,Number)" +
                        "VALUES (@Street,@ZipCode,@Complement,@State,@Neighborhood,@City,@Number); SELECT CAST(SCOPE_IDENTITY() as int)", new
                        {
                            
                            client.Adress.Street,
                            client.Adress.ZipCode,
                            client.Adress.Complement,
                            client.Adress.State,
                            client.Adress.Neighborhood,
                            client.Adress.City,
                            client.Adress.Number

                        },transaction);
                    cpf = connection.ExecuteScalar<string>("INSERT INTO TB_PERSON (Document,Name,BirthDate,Phone,Email,IdAdress)" +
                        " OUTPUT INSERTED.Document " +
                        "VALUES (@Document,@Name,@BirthDate,@Phone,@Email,@IdAdress)", new
                        {
                            client.Document,
                            client.Name,
                            client.BirthDate,
                            client.Phone,
                            client.Email,
                            IdAdress
                        },transaction);
                    connection.Execute("INSERT INTO TB_CLIENT (Document,Income,DocumentPDF) VALUES (@Document,@Income,@DocumentPDF)", new
                    {
                        client.Document,
                        client.Income,
                        client.DocumentPDF
                    },transaction);
                    transaction.Commit();
                    connection.Close();
                }
            
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void EmployeeInsert(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void PurchaseInsert(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        public void SaleInsert(Sale sale)
        {
            throw new NotImplementedException();
        }
    }
}
