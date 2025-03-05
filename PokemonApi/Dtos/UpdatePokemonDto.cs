using System.Runtime.Serialization;

namespace PokemonApi.Dtos;

[DataContract (Name = "UpdatePokemonDto", Namespace = "h")]

public class UpdatePokemonDto : PokemonCommonDto{
    [DataMember(Name = "Id", Order = 5)]

    public Guid Id {get; set;}
}