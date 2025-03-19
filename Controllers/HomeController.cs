using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ProjetoVagas.Data;

namespace ProjetoVagas.Controllers
{
    public class HomeController : Controller
    {
        private readonly AdzunaService _adzunaService;

        public HomeController(AdzunaService adzunaService)
        {
            _adzunaService = adzunaService;
        }

        // Exibe a página inicial com as primeiras 10 vagas armazenadas
        public async Task<IActionResult> Index()
        {
            // Obtém as primeiras 10 vagas do banco de dados
            var vagas = await _adzunaService.ObterVagasAsync(0, 10);

            return View(vagas);
        }

        // Exibe os detalhes de uma vaga específica pelo ID
        [Route("Vaga")]
        public async Task<IActionResult> Detalhes(string id)
        {
            var vaga = await _adzunaService.ObterVagaPorIdAsync(id);

            if (vaga == null)
            {
                return NotFound();
            }

            return View(vaga);
        }

        // Realiza uma pesquisa de vagas e exibe os resultados na página inicial
        [HttpGet]
        public async Task<IActionResult> Pesquisar(string query)
        {
            // Chama o serviço para buscar vagas que correspondem ao termo de pesquisa
            var vagas = await _adzunaService.PesquisarVagasAsync(query);

            // Retorna os resultados na view Index
            return View("Index", vagas);
        }

        // Carrega mais vagas de acordo com o número de registros passados (rolagem infinita)
        [HttpGet]
        public async Task<IActionResult> CarregarVagas(int skip = 0, int take = 10)
        {
            var vagas = await _adzunaService.ObterVagasAsync(skip, take);
            return PartialView("_VagasPartial", vagas);
        }
    }
}




/*
 * 
 * using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ProjetoVagas.Data;

namespace ProjetoVagas.Controllers
{
    public class HomeController : Controller
    {
        private readonly AdzunaService _adzunaService;

        public HomeController(AdzunaService adzunaService)
        {
            _adzunaService = adzunaService;
        }

        // Método que chama o serviço para buscar e salvar as vagas no banco de dados
        public async Task<IActionResult> Index()
        {
            // Atualiza as vagas no banco de dados chamando o serviço
            await _adzunaService.AtualizarVagasAsync();

            // Busca as primeiras 10 vagas do banco de dados para exibir na view
            var vagas = await _adzunaService.ObterVagasAsync(0, 10);

            return View(vagas);
        }


        [Route("Vaga")]
        public async Task<IActionResult> Detalhes(string id)
        {


            var vaga = await _adzunaService.ObterVagaPorIdAsync(id);

          
            if (vaga == null)
            {
                return NotFound(); 
            }

            
            return View(vaga);


        }

        [HttpGet]
        public async Task<IActionResult> Pesquisar(string query)
        {
            // Chama o método de serviço para obter as vagas que correspondem à pesquisa
            var vagas = await _adzunaService.PesquisarVagasAsync(query);

            // Retorna a view com as vagas encontradas
            return View("Index", vagas); // Supondo que você deseja retornar para a view Index
        }

        //metodo para voltar vagas ao rolar
        [HttpGet]
        public async Task<IActionResult> CarregarVagas(int skip = 0, int take = 10)
        {
            var vagas = await _adzunaService.ObterVagasAsync(skip, take);
            return PartialView("_VagasPartial", vagas);
        }



    }
}











 */







