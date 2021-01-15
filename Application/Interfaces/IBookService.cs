using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBookService
    {
        Task<IReadOnlyList<BookDto>> GetBooks();
        Task<BookDto> GetBookById(string id);
        Task<BookDto> UpdateBook(string id, BookDto book);
        Task<BookDto> CreateBook(Book model);
        Task DeleteBook(string id);
    }
}
