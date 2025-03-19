using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjetoVagas.Data;
using ProjetoVagas.Models;
using ProjetoVagas.Repositorio;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class AdzunaService : IAdzunaService
{
    private readonly VagaDbContext _context;
    private readonly HttpClient _httpClient;
    private int _counter = 1;

    public AdzunaService(VagaDbContext context, HttpClient httpClient)
    {
        _context = context;
        _httpClient = httpClient;
    }

    public async Task FetchAndStoreJobsAsync(int page)
    {
        try
        {
            string apiUrl = $"Link da api";

            var response = await _httpClient.GetAsync(apiUrl).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var responseBytes = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            var responseString = Encoding.UTF8.GetString(responseBytes);

            var apiResponse = JsonConvert.DeserializeObject<AdzunaResponse>(responseString);

            if (apiResponse?.Results != null && apiResponse.Results.Count > 0)
            {
                foreach (var job in apiResponse.Results)
                {
                    var existingJob = await _context.Vagas.FirstOrDefaultAsync(x => x.Id == job.Id).ConfigureAwait(false);

                    if (existingJob == null)
                    {
                        var vaga = new Vaga
                        {
                            Id = job.Id,
                            Title = job.Title,
                            Description = job.Description,
                            Redirect_url = job.Redirect_url ?? "N/A",
                            Created = job.Created,
                            Location = new Location
                            {
                                Display_name = job.Location?.Display_name ?? "Local não informado",
                                Area = job.Location?.Area ?? new List<string>()
                            },
                            Company = new Company
                            {
                                Display_name = job.Company?.Display_name ?? "Empresa não informada"
                            }
                        };

                        _context.Vagas.Add(vaga);
                    }
                }

                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
        catch (Exception ex)
        {
            // Logar o erro usando ILogger
            Console.WriteLine($"Erro durante a atualização das vagas: {ex.Message}");
        }
    }

    public async Task<List<Vaga>> ObterVagasAsync()
    {
        return await _context.Vagas.ToListAsync().ConfigureAwait(false);
    }

    public async Task<Vaga> ObterVagaPorIdAsync(string id)
    {
        return await _context.Vagas.FirstOrDefaultAsync(v => v.Id == id).ConfigureAwait(false);
    }

    public async Task<List<Vaga>> PesquisarVagasAsync(string query)
    {
        return await _context.Vagas
            .Where(v =>
                v.Title.Contains(query) ||
                v.Location.Display_name.Contains(query) ||
                v.Company.Display_name.Contains(query))
            .ToListAsync().ConfigureAwait(false);
    }

    public async Task<List<Vaga>> ObterVagasAsync(int skip, int take)
    {
        return await _context.Vagas
            .OrderByDescending(v => v.Created) // atenção aqui, pois talvez mostre só as vagas mais antigas ou as mais novas!
            .Skip(skip)
            .Take(take)
            .ToListAsync().ConfigureAwait(false);
    }
}










