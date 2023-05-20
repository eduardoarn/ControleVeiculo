namespace ControleVeiculo.Models;

public interface IBaseModel
{
    public Guid Id { get; set; }
    public DateTime DataCriacao { get; set; }
    public Guid UsuarioCriacao { get; set; }
    public DateTime DataAlteracao { get; set; }
    public Guid UsuarioAlteracao { get; set; }
}