using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Client : Person
    {
        public Decimal Income { get; set; }
        //public Client(Decimal income, string pdf, string cpf, string name, DateTime bd, string phone, string email, string street, string zipcode, string complement, string state,string neighborhood, string city, string number)
        //{
        //    this.Income = income;
        //    this.Document = cpf;
        //    this.Name = name;
        //    this.BirthDate = bd;
        //    this.Phone = phone;
        //    this.Email = email;
        //    this.Adress = new Adress
        //    {
        //        Street = street,
        //        ZipCode = zipcode,
        //        Complement = complement,
        //        State = state,
        //        Neighborhood = neighborhood,
        //        City = city,
        //        Number = number
        //    };
        //    //this.Adress.Id = idAdress;
        //    //    this.Adress.Street = street;
        //    //    this.Adress.ZipCode = zipcode;
        //    //    this.Adress.Complement = complement;
        //    //    this.Adress.State = state;
        //    //    this.Adress.City = city;
        //    //    this.Adress.Number = number;
        //    //}
        //}
    }
}
