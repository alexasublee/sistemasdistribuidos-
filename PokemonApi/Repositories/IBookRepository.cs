using PokemonApi.Dtos;
using PokemonApi.Models;

namespace PokemonApi.Repositories;

public interface IBookRepository{
    Task DeleteBook(Book book, CancellationToken cancellationToken);
    Task<Book> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}