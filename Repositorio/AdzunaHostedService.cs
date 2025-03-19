using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjetoVagas.Repositorio;
using System.Threading;
using System.Threading.Tasks;

public class AdzunaHostedService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider; // Usar IServiceProvider
    private readonly ILogger<AdzunaHostedService> _logger;

    public AdzunaHostedService(IServiceProvider serviceProvider, ILogger<AdzunaHostedService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        int page = 1;

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope()) // Criar escopo
                {
                    var adzunaService = scope.ServiceProvider.GetRequiredService<IAdzunaService>();
                    _logger.LogInformation($"Iniciando busca na API para a página {page}");
                    await adzunaService.FetchAndStoreJobsAsync(page); // Método que executa a chamada API e armazena no banco
                }

                page++;
                if (page > 24) page = 1; // Resetando para 1 após 24 horas

                _logger.LogInformation("Processo concluído. Aguardando 1 hora...");
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken); // Delay de 1 hora
            }
            catch (TaskCanceledException ex)
            {
                _logger.LogWarning("Processo foi cancelado: " + ex.Message);
                break; // Encerrando se a tarefa foi cancelada
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro durante a execução: {ex.Message}");
            }
        }
    }
}




