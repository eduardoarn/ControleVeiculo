using ControleVeiculo.Data;
using ControleVeiculo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleVeiculo.Controllers;

[ApiController]
[Route("[controller]")]
public class AbastecimentoController : BaseController<Models.Abastecimento>
{
    private readonly DataContext _context;
    private readonly IConfiguration _configuration;
    private readonly int _totalPaginas;

    public AbastecimentoController(ILogger<BaseController<Abastecimento>> logger, DataContext context, IConfiguration configuration) : base(logger, context)
    {
        _context = context;
        _configuration = configuration;
        _totalPaginas = _configuration.GetValue<int>("TotalPaginas");
    }

    [HttpGet]
    public async Task<Helpers.ListaRetorno<Models.Abastecimento>> Get(DateOnly? De, DateOnly? Ate, Guid? VeiculoId, Guid? MotoristaId, int pagina = 1)
    {
        var query = _context.Abastecimentos.AsQueryable().AsNoTracking();
        DateTime hoje = DateTime.Today;
        //Verifica se De for null e define ele como primeiro dia do mês atual
        if (De is not null) De = new DateOnly(hoje.Year, hoje.Month, 1);
        if (Ate is not null) Ate = new DateOnly(hoje.Year, hoje.Month, DateTime.DaysInMonth(hoje.Year, hoje.Month));
        query = query.Where(x => DateOnly.FromDateTime(x.DataLancamento) >= De && DateOnly.FromDateTime(x.DataLancamento) <= Ate);

        if (VeiculoId is not null)
        {
            query = query.Where(x => x.VeiculoId == VeiculoId);
        }

        if (MotoristaId is not null)
        {
            query = query.Where(x => x.MotoristaId == MotoristaId);
        }

        // if (filtro is not null)
        // {
        //     //query = query.Where(x => EF.Functions.ILike(x.da, $"%{filtro}%") || EF.Functions.ILike(x.PrimeiroNome, $"%{filtro}%") || EF.Functions.ILike(x.SobreNome, $"%{filtro}%"));
        // }
        query = query.Include(x => x.Veiculo).Include(x => x.Motorista);

        return new Helpers.ListaRetorno<Models.Abastecimento>()
        {
            Lista = await query.OrderBy(x => x.DataLancamento).Skip((pagina - 1) * 10).Take(_totalPaginas).ToListAsync(),
            TotalRegistros = await query.CountAsync(),
            PaginaAtual = pagina,
            TamanhoPagina = _totalPaginas
        };
    }
}