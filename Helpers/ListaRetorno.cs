namespace ControleVeiculo.Helpers;

public class ListaRetorno<T> where T : Models.IBaseModel
{
    public IEnumerable<T> Lista { get; set; } = null!;
    public int TotalRegistros { get; set; }
    public int PaginaAtual { get; set; }
    public int TamanhoPagina { get; set; }
}