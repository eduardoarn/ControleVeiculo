using ControleVeiculo.Data;
using ControleVeiculo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleVeiculo.Controllers;

[ApiController]
[Route("[controller]")]
public class VeiculoController : BaseController<Models.Veiculo>
{
    public VeiculoController(ILogger<BaseController<Veiculo>> logger, DataContext context) : base(logger, context)
    {
    }
}