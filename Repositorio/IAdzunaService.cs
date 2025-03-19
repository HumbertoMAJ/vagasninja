using Newtonsoft.Json;
using ProjetoVagas.Data;
using ProjetoVagas.Models;
using System.Text;

namespace ProjetoVagas.Repositorio
{
    public interface IAdzunaService
    {
        Task FetchAndStoreJobsAsync(int page);
        Task<List<Vaga>> ObterVagasAsync();
        Task<Vaga> ObterVagaPorIdAsync(string id);
        Task<List<Vaga>> PesquisarVagasAsync(string query);
        Task<List<Vaga>> ObterVagasAsync(int skip, int take);
    }

   

}
