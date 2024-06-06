using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee : Person
    {
        public Position Position { get; set; }
        public Decimal ComissionValue { get; set; } // Porcentagem
        public Decimal Comission { get; set; } //
    }
}
