using ProjetoVagas.Models;

public class AdzunaResponse
{
    public List<Vaga> Results { get; set; } // Mapeia a propriedade 'results' do JSON
    public int Count { get; set; }
    public decimal Mean { get; set; }
}
