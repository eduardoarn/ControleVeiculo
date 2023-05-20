using System.ComponentModel.DataAnnotations;

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
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public Guid UsuarioCriacao { get; set; }
    public DateTime DataAlteracao { get; set; } = DateTime.Now;
    public Guid UsuarioAlteracao { get; set; }
}