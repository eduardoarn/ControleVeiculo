using System.Text.Json.Serialization;

namespace ControleVeiculo.Models;

public class Motorista : IBaseModel
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string PrimeiroNome { get; set; } = null!;
    public string SobreNome { get; set; } = null!;
    public string NomeCompleto { get { return $"{PrimeiroNome} {SobreNome}"; } }
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