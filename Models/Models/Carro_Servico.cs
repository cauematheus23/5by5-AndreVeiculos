using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Carro_Servico
    {
        public readonly static string SELECT = "SELECT cs.Status,c.Placa,c.Nome,c.AnoModelo,c.AnoFabricacao,c.Cor,s.Id,s.Descricao from TB_CARROSERVICO cs inner join TB_CARRO c ON cs.PlacaCarro = c.Placa inner join TB_SERVICO s ON cs.IdServico = s.Id WHERE Status = 1;";
        public int Id { get; set; }
        public Carro Carro { get; set; }    
        public Servico Servico { get; set; }
        public bool Status { get; set; }

        public override string? ToString() => $"\n{Carro}\nServiço {Servico}\nStatus: {Status}";
    }
}
