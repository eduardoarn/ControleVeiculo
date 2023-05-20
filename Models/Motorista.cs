namespace ControleVeiculo.Models;

public class Motorista : IBaseModel
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string PrimeiroNome { get; set; } = null!;
    public string SobreNome { get; set; } = null!;
    public string NomeCompleto { get { return $"{PrimeiroNome} {SobreNome}"; } }
    public virtual IEnumerable<MotoristaVeiculo>? MotoristaVeiculos { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public Guid UsuarioCriacao { get; set; }
    public DateTime DataAlteracao { get; set; } = DateTime.Now;
    public Guid UsuarioAlteracao { get; set; }
}