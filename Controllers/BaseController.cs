using ControleVeiculo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

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

    [HttpPut]
    public async Task<IActionResult> Update(T itemAdd)
    {
        //Validar o itemAdd.Id que é do tipo Guid é diferente de null
        if (itemAdd is null) return BadRequest(new { message = "Objeto informado é nulo" });
        if (itemAdd.Id == Guid.Empty) return BadRequest(new { message = "Objeto informado contem dados inválidos" });

        itemAdd.DataAlteracao = DateTime.Now;
        if (ModelState.IsValid)
        {
            //valida se o item existe no banco e retorna ele para uma variável
            var item = await _context.Set<T>().FindAsync(itemAdd.Id);
            if (item == null) return BadRequest(new { message = "Objeto não encontrado na base de dados" });
            _context.Update(itemAdd);
            await _context.SaveChangesAsync();
            return Ok(itemAdd);
        }
        return BadRequest(ModelState);
    }
}