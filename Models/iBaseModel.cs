using System.Text.Json.Serialization;

namespace ControleVeiculo.Models;

public interface IBaseModel
{
    public Guid Id { get; set; }
    [JsonIgnore]
    public DateTime DataCriacao { get; set; }
    [JsonIgnore]
    public Guid UsuarioCriacao { get; set; }
    [JsonIgnore]
    public DateTime DataAlteracao { get; set; }
    [JsonIgnore]
    public Guid UsuarioAlteracao { get; set; }
}