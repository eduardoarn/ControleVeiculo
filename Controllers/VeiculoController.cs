using ControleVeiculo.Data;
using ControleVeiculo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleVeiculo.Controllers;

[ApiController]
[Route("[controller]")]
public class VeiculoController : BaseController<Models.Veiculo>
{
    private readonly DataContext _context;
    private readonly IConfiguration _configuration;
    private readonly int _totalPaginas;

    public VeiculoController(ILogger<BaseController<Veiculo>> logger, DataContext context, IConfiguration configuration) : base(logger, context)
    {
        _context = context;
        _configuration = configuration;
        _totalPaginas = _configuration.GetValue<int>("TotalPaginas");
    }

    [HttpGet]
    public async Task<Helpers.ListaRetorno<Models.Veiculo>> Get(string? filtro, int pagina = 1)
    {
        var query = _context.Veiculos.AsQueryable().AsNoTracking();
        if (!string.IsNullOrEmpty(filtro))
        {
            query = query.Where(x => EF.Functions.ILike(x.Placa, $"%{filtro}%") || EF.Functions.ILike(x.Marca, $"%{filtro}%") || EF.Functions.ILike(x.Modelo, $"%{filtro}%"));
        }
        query = query.Include(x => x.MotoristaVeiculos)!.ThenInclude(x => x.Motorista);

        return new Helpers.ListaRetorno<Models.Veiculo>()
        {
            Lista = await query.OrderBy(x => x.Placa).Skip((pagina - 1) * 10).Take(_totalPaginas).ToListAsync(),
            TotalRegistros = await query.CountAsync(),
            PaginaAtual = pagina,
            TamanhoPagina = _totalPaginas
        };
    }
}