using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Models
{
    public class GenerateXMLs
    {
        public bool GenerateXMLCarroVermelho(List<Carro> lst)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\Dados\\";
            string file = "RedCars";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(path + file))
            {
                var x = File.Create(path + file);
                x.Close();
            }
            if (lst.Count > 0)
            {
                var infracao = new XElement("Root", from carro in lst
                                                    select new XElement("Carro",
                                                        new XElement("Placa", carro.Placa),
                                                        new XElement("Nome", carro.Nome),
                                                        new XElement("AnoModelo", carro.AnoModelo),
                                                        new XElement("AnoFabricacao", carro.AnoFabricacao),
                                                        new XElement("Cor", carro.Cor)
                                                    )
                );

                StreamWriter sw = new StreamWriter(path + file);
                sw.Write(infracao);
                sw.Close();
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool GenerateXMLStatusTrue(List<Carro> lst)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\Dados\\";
            string file = "CarStatsTrue";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(path + file))
            {
                var x = File.Create(path + file);
                x.Close();
            }
            if (lst.Count > 0)
            {
                var infracao = new XElement("Root", from carro in lst
                                                    select new XElement("Carro",
                                                        new XElement("Placa", carro.Placa),
                                                        new XElement("Nome", carro.Nome),
                                                        new XElement("AnoModelo", carro.AnoModelo),
                                                        new XElement("AnoFabricacao", carro.AnoFabricacao),
                                                        new XElement("Cor", carro.Cor)
                                                    )
                );

                StreamWriter sw = new StreamWriter(path + file);
                sw.Write(infracao);
                sw.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public  bool GenerateXMLAnoFabricado(List<Carro> lst)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Documents\\Dados\\";
            string file = "CarsFabricateBetween";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(path + file))
            {
                var x = File.Create(path + file);
                x.Close();
            }
            if (lst.Count > 0)
            {
                var infracao = new XElement("Root", from carro in lst
                                                    select new XElement("Carro",
                                                        new XElement("Placa", carro.Placa),
                                                        new XElement("Nome", carro.Nome),
                                                        new XElement("AnoModelo", carro.AnoModelo),
                                                        new XElement("AnoFabricacao", carro.AnoFabricacao),
                                                        new XElement("Cor", carro.Cor)
                                                    )
                );

                StreamWriter sw = new StreamWriter(path + file);
                sw.Write(infracao);
                sw.Close();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
