namespace ControleVeiculo.Models;

public class Veiculo : IBaseModel
{
    public Guid Id { get; set; }
    public string Marca { get; set; } = null!;
    public string Modelo { get; set; } = null!;
    public string Placa { get; set; } = null!;
    public string Localidade { get; set; } = null!;
    public virtual IEnumerable<MotoristaVeiculo>? MotoristaVeiculos { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public Guid UsuarioCriacao { get; set; }
    public DateTime DataAlteracao { get; set; } = DateTime.Now;
    public Guid UsuarioAlteracao { get; set; }
}