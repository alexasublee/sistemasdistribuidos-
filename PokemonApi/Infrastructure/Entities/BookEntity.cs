namespace PokemonApi.Infrastructure.Entities;

public class BookEntity
{
   public Guid Id{get; set;}
    public String Title{get; set;}
    public string Author{get; set;}

    public DateTime PublishedDate{get; set;}

}