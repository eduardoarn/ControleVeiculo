using System.Text.Json.Serialization;

namespace ControleVeiculo.Models;

public class Veiculo : IBaseModel
{
    public Guid Id { get; set; }
    public string Marca { get; set; } = null!;
    public string Modelo { get; set; } = null!;
    public string Placa { get; set; } = null!;
    public string Localidade { get; set; } = null!;
    public virtual IEnumerable<MotoristaVeiculo>? MotoristaVeiculos { get; set; }
    [JsonIgnore]
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    [JsonIgnore]
    public Guid UsuarioCriacao { get; set; }
    [JsonIgnore]
    public DateTime DataAlteracao { get; set; } = DateTime.Now;
    [JsonIgnore]
    public Guid UsuarioAlteracao { get; set; }
}