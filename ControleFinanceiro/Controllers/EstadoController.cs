using ControleFinanceiro.Data;
using ControleFinanceiro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Linq.Expressions;

namespace ControleFinanceiro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoController : Controller
    {
        private readonly ControleFinanceiroDbContext _context;

        public EstadoController(ControleFinanceiroDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetEstados()
        {
            try
            {
                var result = _context.Estado.ToList();

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro na listagem de estados:Exceção: {e.Message}");
            }

        }

        [HttpGet("{sigla}")]
        public IActionResult GetEstadosSigla([FromRoute] string sigla)
        {
            try
            {
                var estado = _context.Estado.Find(sigla);
                if (estado.Sigla == sigla && !string.IsNullOrEmpty(estado.Sigla))
                {
                    return Ok(estado);
                }
                else
                {
                    return NotFound("Erro,estado não existe");
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Erro, estado não encontrado.Exceção: {e.Message}");
            }

        }

        [HttpGet("Pesquisa")]
        public IActionResult GetEstadoPesquisa([FromQuery] string valor)
        {

            
            try
            {
                //Query Criteria (Método LINQ)
                var lista = from o in _context.Estado.ToList()
                            where o.Sigla.ToUpper().Contains(valor.ToUpper())
                            || o.Nome.ToUpper().Contains(valor.ToUpper())
                            select o;

                /* método com Expression
                 
                Expression<Func<Estado, bool>> expressao = o => true;
                expressao = o => o.Sigla.ToUpper().Contains(valor.ToUpper())
                              || o.Nome.ToUpper().Contains(valor.ToUpper())

                lista = _context.Estado.Where(expressao).ToList();*/

                /*Método com Entity framework
                 
                lista = _context.Estado
                    .Where(o => o.Sigla.ToUpper().Contains(valor.ToUpper())
                    || o.Nome.ToUpper().Contains(valor.ToUpper())
                    )
                .Tolist();
                */

                return Ok(lista);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro, estado não encontrado.Exceção: {e.Message}");
            }

        }

        [HttpGet("Paginacao")]
        public IActionResult GetEstadoPaginacao([FromQuery] string valor,int skip, int take, bool ordemDecrescente)
        {

            try
            {
                //Query Criteria (Método LINQ)
                var lista = from o in _context.Estado.ToList()
                            where o.Sigla.ToUpper().Contains(valor.ToUpper())
                            || o.Nome.ToUpper().Contains(valor.ToUpper())
                            select o;

                if (ordemDecrescente)
                {
                    lista = from o in lista
                            orderby o.Nome descending
                            select o;
                }
                else
                {
                    lista = from o in lista
                            orderby o.Nome ascending
                            select o;
                }

                var quantidade = lista.Count();

                lista = lista.Skip(skip).Take(take).ToList();

                var paginacaoResponse = new PaginacaoResponse<Estado>(lista, quantidade, skip, take);
                return Ok(paginacaoResponse);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro, estado não encontrado.Exceção: {e.Message}");
            }

        }

        [HttpPost]
        public IActionResult PostEstados([FromBody] Estado estado)
        {
            try
            {
                _context.Estado.Add(estado);
                var valor = _context.SaveChanges();
                if (valor == 1)
                {
                    return Ok("Sucesso,estado incluído");
                }
                else
                {
                    return BadRequest($"Erro, estado não incluído");
                }

            }
            catch (Exception e)
            {
                return BadRequest($"Erro, estado não incluído.Exceção: {e.Message}");
            }

        }

        [HttpPut]
        public IActionResult PutEstados([FromBody] Estado estado)
        {
            try
            {
                _context.Estado.Update(estado);
                var valor = _context.SaveChanges();
                if (valor == 1)
                {
                    return Ok("Sucesso,estado alterado");
                }
                else
                {
                    return BadRequest($"Erro, estado não incluído");
                }

            }
            catch (Exception e)
            {
                return BadRequest($"Erro, estado não incluído.Exceção: {e.Message}");
            }

        }

        [HttpDelete("{sigla}")]
        public IActionResult DeleteEstados([FromRoute] string sigla)
        {
            try
            {
                var estado = _context.Estado.Find(sigla);
                if (estado.Sigla == sigla && !string.IsNullOrEmpty(estado.Sigla)) 
                {
                    _context.Estado.Remove(estado);
                    var valor = _context.SaveChanges();
                    if (valor == 1)
                    {
                        return Ok("Estado excluído");
                    }
                    else
                    {
                        return BadRequest("Erro,estado não excluído");
                    }
                }
                else
                {
                    return NotFound("Erro,estado não existe");
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Erro, estado não excluído.Exceção: {e.Message}");
            }

        }
    }
}
