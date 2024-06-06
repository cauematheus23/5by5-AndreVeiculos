// See https://aka.ms/new-console-template for more information

using Models;
using Repositories;

Client c = new Client(income: 1000, pdf: "pdf", cpf: "cpf", name: "name", bd: new DateTime(2000, 1, 1), phone: "phone", email: "email",street: "street", zipcode: "zipcode", complement: "complement", state: "state",neighborhood: "teste", city: "city", number: "number");

Repository r = new Repository();
r.ClientInsert(c);
