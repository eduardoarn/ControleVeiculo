using System.Text.Json.Serialization;

namespace ControleVeiculo.Models;

public class TurnoLancamento : IBaseModel
{
    public Guid Id { get; set; }
    public Guid MotoristaId { get; set; }
    public virtual Motorista? Motorista { get; set; }
    public Guid VeiculoId { get; set; }
    public virtual Veiculo? Veiculo { get; set; }

    public DateTime DataLancamentoInicio { get; set; }
    public DateTime? DataLancamentoFim { get; set; }
    public int KmEntrada { get; set; }
    public int KmSaida { get; set; }
    public bool Reserva { get; set; } = false;

    [JsonIgnore]
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    [JsonIgnore]
    public Guid UsuarioCriacao { get; set; }
    [JsonIgnore]
    public DateTime DataAlteracao { get; set; } = DateTime.Now;
    [JsonIgnore]
    public Guid UsuarioAlteracao { get; set; }
}