using System.Runtime.Serialization;
using PokedexApi.Dtos;

namespace PokedexApi.Infrastrucure.Soap.Dtos;

public class PokemonResponse{
   [DataMember(Name = "Id", Order = 1)]
    public Guid Id {get; set;}
    [DataMember(Name = "Name", Order = 2)]
    public string Name {get; set;}
    [DataMember(Name = "Type", Order = 3)]
    public string Type {get; set;}
    [DataMember(Name = "Level", Order = 4)]
    public int Level {get; set;}

    [DataMember(Name = "Gender", Order = 5)]
    public  string Gender {get; set;}
    
    [DataMember(Name = "Stats", Order = 6)]
    public StatsResponse Stats {get; set;}

}