using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Adress
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Complement { get; set; }
        public string State { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string Number { get; set; }

        public override string? ToString() => $"Id: {Id}\nStreet: {Street}\nZipCode: {ZipCode}\nComplement: {Complement}\nState: {State}\nNeighborhood: {Neighborhood}\nCity: {City}\nNumber: {Number}";
    }
}
