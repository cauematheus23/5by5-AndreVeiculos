using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class ReadFile
    {
        public static List<Carro> GetCarros(string path)
        {
            StreamReader sw = new StreamReader(path);
            string jsonString = sw.ReadToEnd();
            var lst = JsonConvert.DeserializeObject<List<Carro>>(jsonString);

            if (lst != null) return lst;return null;
        }
    }
}
