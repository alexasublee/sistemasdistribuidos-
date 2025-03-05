using System.Formats.Asn1;
using System.ServiceModel;
using PokemonApi.Dtos;
using PokemonApi.Mappers;
using PokemonApi.Models;
using PokemonApi.Repositories;

namespace PokemonApi.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository){
        _bookRepository = bookRepository;
    }
 
 public async Task<BookResponseDto> GetBookById(Guid id, CancellationToken cancellationToken){
        var book = await _bookRepository.GetByIdAsync(id, cancellationToken);
        if (book is null){
            throw new FaultException("Book Not Found :(");
        }
        return book.ToDto();
    }

    public async Task<bool> DeleteBook(Guid Id, CancellationToken cancellationToken){
        var book = await _bookRepository.GetByIdAsync(Id,  cancellationToken);
        if(book is null){
        throw new FaultException("book not found ");
    }
        await _bookRepository.DeleteBook(book, cancellationToken);
        return true;
    }


}

