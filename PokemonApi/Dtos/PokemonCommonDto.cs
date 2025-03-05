using System.Runtime.Serialization;

namespace PokemonApi.Dtos;

[DataContract(Name = "PokemonCommonDto", Namespace = "http://pokemon.api/pokemon-s")]
[KnownType(typeof(CreatePokemonDto))]
[KnownType(typeof(UpdatePokemonDto))]

public class PokemonCommonDto{
    
    [DataMember(Name ="Name", Order =1)]
    public string Name {get; set;}
    [DataMember(Name ="Type", Order =2)]

    public string Type {get; set;}
    [DataMember(Name ="Level", Order =3)]

    public int Level {get; set;}
    [DataMember(Name ="Gender", Order =4)]



    public string Gender {get; set;}
    [DataMember(Name ="Stats", Order =5)]

    public StatsDto Stats {get; set;}



}