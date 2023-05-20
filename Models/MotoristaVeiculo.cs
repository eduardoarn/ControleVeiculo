namespace ControleVeiculo;

public class MotoristaVeiculo
{
    public Guid VeiculoId { get; set; }
    public virtual Veiculo? Veiculo { get; set; }
    public Guid MotoristaId { get; set; }
    public virtual Motorista? Motorista { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public Guid UsuarioCriacao { get; set; }
    public DateTime DataAlteracao { get; set; } = DateTime.Now;
    public Guid UsuarioAlteracao { get; set; }
}