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


    [HttpGet("{id}")]
    public async Task<T> GetById(Guid id)
    {
        var r = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id)!;
        if (r is not null) return r;
        else throw new Exception("Objeto não encontrado");

    }

    [HttpPut]
    public async Task<IActionResult> Update(T itemAtualizar)
    {
        //Validar o itemAdd.Id que é do tipo Guid é diferente de null
        if (itemAtualizar is null) return BadRequest(new { message = "Objeto informado é nulo" });
        if (itemAtualizar.Id == Guid.Empty) return BadRequest(new { message = "Objeto informado contem dados inválidos" });

        itemAtualizar.DataAlteracao = DateTime.Now;
        if (ModelState.IsValid)
        {
            //valida se o item existe no banco e retorna ele para uma variável
            var itemBanco = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == itemAtualizar.Id);
            if (itemBanco == null) return BadRequest(new { message = "Objeto não encontrado na base de dados" });
            itemAtualizar.DataCriacao = itemBanco.DataCriacao;
            itemAtualizar.UsuarioCriacao = itemBanco.UsuarioCriacao;
            _context.Update(itemAtualizar);
            await _context.SaveChangesAsync();
            return Ok(itemAtualizar);
        }
        return BadRequest(ModelState);
    }
}