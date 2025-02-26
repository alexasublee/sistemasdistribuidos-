using Microsoft.EntityFrameworkCore.Storage.Json;
using PokemonApi.Dtos;
using PokemonApi.Infrastructure.Entities;
using PokemonApi.Models;

namespace PokemonApi.Mappers;

public static class PokemonMapper{
    public static PokemonEntity ToEntity(this Pokemon pokemon){
        return new PokemonEntity{
            Id= pokemon.Id,
            Name = pokemon.Name,
            Type = pokemon.Type,
            Level = pokemon.Level,
            Gender = pokemon.Gender, 
            Attack = pokemon.Stats.Attack,
            Defense = pokemon.Stats.Defense,
            

            Speed = pokemon.Stats.Speed
        };
    }
    public static Pokemon ToModel(this PokemonEntity entity){
        if (entity is null){
            return null;
        }
        return new Pokemon{
            Id= entity.Id,
            Name = entity.Name,
            Type = entity.Type,
            Level = entity.Level, 
            Gender = entity.Gender,
            Stats = new Stats{
                Attack = entity.Attack,
                Defense = entity.Defense,
                Speed = entity.Speed
                
            }
        };

    }

    public static PokemonResponseDto ToDto(this Pokemon pokemon){
        return new PokemonResponseDto{
            Id = pokemon.Id,
            Name = pokemon.Name,
            Type = pokemon.Type,
            Level = pokemon.Level,
            Gender = pokemon.Gender,
 
            Stats = new StatsDto{
                Attack = pokemon.Stats.Attack,
                Speed = pokemon.Stats.Speed,
                Defense = pokemon.Stats.Defense
                
            }
        };
    }
    
}