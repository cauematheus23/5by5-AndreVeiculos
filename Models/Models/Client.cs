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
        public string DocumentPDF { get; set; }
    }
}
