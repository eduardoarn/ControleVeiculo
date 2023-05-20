using System.Text.Json.Serialization;

namespace ControleVeiculo.Models;
public class MotoristaVeiculo
{
    public Guid VeiculoId { get; set; }
    public virtual Veiculo? Veiculo { get; set; }
    public Guid MotoristaId { get; set; }
    public virtual Motorista? Motorista { get; set; }
    [JsonIgnore]
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    [JsonIgnore]
    public Guid UsuarioCriacao { get; set; }
    [JsonIgnore]
    public DateTime DataAlteracao { get; set; } = DateTime.Now;
    [JsonIgnore]
    public Guid UsuarioAlteracao { get; set; }
}