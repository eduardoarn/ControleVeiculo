using ControleVeiculo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ControleVeiculo.Controllers;

public class BaseController<T> : ControllerBase where T : class, Models.IBaseModel
{
    private readonly ILogger<BaseController<T>> _logger;
    private readonly DataContext _context;

    public BaseController(ILogger<BaseController<T>> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(T itemAdd)
    {
        if (itemAdd is null) return BadRequest(new { message = "Objeto informado é nulo" });
        itemAdd.Id = Guid.NewGuid();
        itemAdd.DataAlteracao = DateTime.Now;
        itemAdd.DataCriacao = DateTime.Now;
        if (ModelState.IsValid)
        {
            _context.Add(itemAdd);
            await _context.SaveChangesAsync();
            return Ok(itemAdd);
        }
        return BadRequest(ModelState);
    }
}