using System.ServiceModel;

using PokemonApi.Dtos;

namespace PokemonApi.Services;

[ServiceContract(Name = "BookService", Namespace ="http://pokemon-api/book-service")]


public interface IBookService
{

    [OperationContract]
    Task<BookResponseDto> GetBookById(Guid Id, CancellationToken cancellationToken);
   

    [OperationContract]
    Task<bool> DeleteBook(Guid Id, CancellationToken cancellationToken);
    
}