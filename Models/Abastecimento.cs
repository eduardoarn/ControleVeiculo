using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ControleVeiculo.Models;

public class Abastecimento : IBaseModel
{
    [Key]
    public Guid Id { get; set; }
    public DateTime DataLancamento { get; set; }
    public Guid MotoristaId { get; set; }
    public virtual Motorista? Motorista { get; set; }
    public Guid VeiculoId { get; set; }
    public virtual Veiculo? Veiculo { get; set; }
    public int KM { get; set; }
    public double Litros { get; set; }
    public decimal Valor { get; set; }
    [JsonIgnore]
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    [JsonIgnore]
    public Guid UsuarioCriacao { get; set; }
    [JsonIgnore]
    public DateTime DataAlteracao { get; set; } = DateTime.Now;
    [JsonIgnore]
    public Guid UsuarioAlteracao { get; set; }
}