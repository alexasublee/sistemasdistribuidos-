namespace PokemonApi.Dtos;

public class PokemonResponseDto
{
    public Guid Id {get; set;}
    public string Name {get; set;}
    public string Type {get; set;}
    public int Level {get; set;}
    
    public string Gender {get; set;}
    public StatsDto Stats{get; set;}


}

