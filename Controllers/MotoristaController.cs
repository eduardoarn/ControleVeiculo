using ControleVeiculo.Data;
using ControleVeiculo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleVeiculo.Controllers;

[ApiController]
[Route("[controller]")]
public class MotoristaController : BaseController<Models.Motorista>
{
    private readonly DataContext _context;
    private readonly IConfiguration _configuration;
    private readonly int _totalPaginas;

    public MotoristaController(ILogger<BaseController<Motorista>> logger, DataContext context, IConfiguration configuration) : base(logger, context)
    {
        _context = context;
        _configuration = configuration;
        _totalPaginas = _configuration.GetValue<int>("TotalPaginas");
    }

    [HttpGet]
    public async Task<Helpers.ListaRetorno<Models.Motorista>> Get(string? filtro, int pagina = 1)
    {
        var query = _context.Motoristas.AsQueryable().AsNoTracking();
        if (filtro is not null)
        {
            query = query.Where(x => EF.Functions.ILike(x.Email, $"%{filtro}%") || EF.Functions.ILike(x.PrimeiroNome, $"%{filtro}%") || EF.Functions.ILike(x.SobreNome, $"%{filtro}%"));
        }
        query = query.Include(x => x.MotoristaVeiculos)!.ThenInclude(x => x.Veiculo);

        return new Helpers.ListaRetorno<Models.Motorista>()
        {
            Lista = await query.OrderBy(x => x.PrimeiroNome).Skip((pagina - 1) * 10).Take(_totalPaginas).ToListAsync(),
            TotalRegistros = await query.CountAsync(),
            PaginaAtual = pagina,
            TamanhoPagina = _totalPaginas
        };
    }
}