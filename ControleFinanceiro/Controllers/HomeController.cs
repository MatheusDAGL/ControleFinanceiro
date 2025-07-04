using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            string result = "Retorno";
            return Ok(result);
        }

        [HttpGet("info2")]
        public IActionResult Index2()
        {
            string result = "Retorno2";
            return Ok(result);
        }


        [HttpGet("info3/{valor}")]
        public IActionResult Index3([FromRoute] string valor)
        {
            string result = "Retorno em texto: Valor " + valor;
            return Ok(result);
        }

        [HttpPost("info4")]
        public IActionResult Index4([FromQuery] string valor)
        {
            string result = "Retorno em texto 4: Valor " + valor;
            return Ok(result);
        }

        [HttpGet("info5")]
        public IActionResult Index5([FromHeader] string valor)
        {
            string result = "Retorno em texto 5: Valor " + valor;
            return Ok(result);
        }

        [HttpPost("info6")]
        public IActionResult Index6([FromBody] Corpo corpo)
        {
            string result = "Retorno em texto 6: Valor " + corpo.valor;
            return Ok(result);
        }
    }

    public class Corpo
    {
        public string valor { get; set; }
    }
}
