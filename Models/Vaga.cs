using Microsoft.EntityFrameworkCore;

namespace ProjetoVagas.Models
{
    public class Vaga
    {
       
            public string Id { get; set; }  // ID da vaga
            public string Title { get; set; }  // Título da vaga
            public string? Description { get; set; }  // Descrição da vaga
            public string? Redirect_url { get; set; }  // URL para mais detalhes da vaga
            public DateTime? Created { get; set; }  // Data de criação da vaga
            public Location? Location { get; set; }  // Objeto Location
            public Company? Company { get; set; }  // Objeto Company
           
       }



    
}
