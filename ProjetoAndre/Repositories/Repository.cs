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
            using(SqlConnection connection = new SqlConnection(Conn))
            {
                connection.Open();
                IdAdress = connection.ExecuteScalar<int>("INSERT INTO TB_ADRESS (Id,Street,ZipCode,Complement,State,City,Number)" +
                    "VALUES (@Id,@Street,@ZipCode,@Complement,@State,@City,@Number); Select cast(SCOPE_IDENTITY() as int)" , new
                    {
                        client.Adress.Id,
                        client.Adress.Street,
                        client.Adress.ZipCode,
                        client.Adress.Complement,
                        client.Adress.State,
                        client.Adress.City,
                        client.Adress.Number

                    });
                cpf = connection.ExecuteScalar<string>("INSERT INTO TB_PERSON (Document,Name,BirthDate,Phone,Email,IdAdress)" +
                    "VALUES (@Document,@Name,@BirthDate,@Phone,@Email,@IdAdress); Select cast(SCOPE_IDENTITY() as int)", new
                    {
                        client.Document,
                        client.Name,
                        client.BirthDate,
                        client.Phone,
                        client.Email,
                        IdAdress
                    });
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
