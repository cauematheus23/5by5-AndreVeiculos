using Newtonsoft.Json;

namespace Models
{
    public class Carro
    {
        public readonly static string INSERT = "INSERT INTO TB_CARRO (Placa, Nome, AnoModelo, AnoFabricacao, Cor) VALUES (@Placa, @Nome, @AnoModelo, @AnoFabricacao, @Cor);";
        public readonly static string INSERTCAST = "INSERT INTO TB_CARRO (Placa, Nome, AnoModelo, AnoFabricacao, Cor) OUTPUT INSERTED.Placa VALUES (@Placa, @Nome, @AnoModelo, @AnoFabricacao, @Cor)";
        public readonly static string SELECT = "SELECT Placa, Nome, AnoModelo, AnoFabricacao, Cor FROM TB_CARRO";
        public readonly static string SELECTStatus = "SELECT Placa, Nome, AnoModelo, AnoFabricacao, Cor FROM TB_CARRO c INNER JOIN TB_CARROSERVICO s ON c.Placa = s.PlacaCarro WHERE s.Status = 1";

        [JsonProperty("Placa")]
        public string Placa { get; set; }
        [JsonProperty("Nome")]
        public string Nome { get; set; }
        [JsonProperty("AnoModelo")]
        public int AnoModelo { get; set; }
        [JsonProperty("AnoFabricacao")]
        public int AnoFabricacao { get; set; }
        [JsonProperty("Cor")]
        public string Cor { get; set; }

        public override string? ToString() => $"Placa: {Placa},\nNome: {Nome},\nAno Modelo: {AnoModelo},\nAno Fabricação: {AnoFabricacao},\nCor: {Cor}";
    }
}
