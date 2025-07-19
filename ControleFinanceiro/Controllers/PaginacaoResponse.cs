using ControleFinanceiro.Models;

namespace ControleFinanceiro.Controllers
{
    internal class PaginacaoResponse
    {
        private IEnumerable<Estado> lista;
        private int quantidade;
        private int skip;
        private int take;

        public PaginacaoResponse(IEnumerable<Estado> lista, int quantidade, int skip, int take)
        {
            this.lista = lista;
            this.quantidade = quantidade;
            this.skip = skip;
            this.take = take;
        }
    }
}