using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.EntityFrameworkCore;
using PokemonApi.Dtos;
using PokemonApi.Infrastructure;
using PokemonApi.Mappers;
using PokemonApi.Models;

namespace PokemonApi.Repositories;

public class BookRepository : IBookRepository
{
    private readonly RelationalDbContext _context;
    public BookRepository(RelationalDbContext context){
        _context=context;
    }
    public async Task<Book> GetByIdAsync(Guid id, CancellationToken cancellationToken){
        var book = await _context.Book.AsNoTracking().FirstOrDefaultAsync(s=> s.Id == id, cancellationToken);
        return book.ToModel();
    }

    public async Task DeleteBook(Book book, CancellationToken cancellationToken){
        _context.Book.Remove(book.ToEntity());
        await _context.SaveChangesAsync(cancellationToken);
    }

}