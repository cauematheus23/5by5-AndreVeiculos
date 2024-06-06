using Newtonsoft.Json;

namespace Models
{
    public class Car
    {
        public string Plate { get; set; }
        public string Name{ get; set; }
        public int ModelYear { get; set; }
        public int FabricationYear { get; set; }
        public string Color { get; set; }
        public override string? ToString() => $"Placa: {Plate},\nNome: {Name},\nAno Modelo: {ModelYear},\nAno Fabricação: {FabricationYear},\nCor: {Color}";
    }
}
