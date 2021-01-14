using Application.Interfaces;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BookDto> CreateBook(Book model)
        {
            var book = await _unitOfWork.Book.Create(model);
            return _mapper.Map<BookDto>(book);
            
        }

        public async Task<BookDto> GetBookById(string id)
        {
            var book = await _unitOfWork.Book.GetByIdAsync(id);
            return _mapper.Map<BookDto>(book);
        }

        public async Task<IReadOnlyList<BookDto>> GetBooks()
        {
            var books = await _unitOfWork.Book.ListAllAsync();
            var booksDto = new List<BookDto>();
            foreach (var item in books)
            {
                booksDto.Add(_mapper.Map<BookDto>(item));
            }
            return booksDto;
        }

        public async Task<BookDto> UpdateBook(string id, BookDto book)
        {
            var bookInDb = await _unitOfWork.Book.GetByIdAsync(id);
            bookInDb.Amount = book.Amount;
            bookInDb.Cover = book.Cover;
            bookInDb.DateModified = DateTime.Now;
            bookInDb.BookUrl = book.BookUrl;
            bookInDb.Description = book.Description;
            bookInDb.ISBN = book.ISBN;
            bookInDb.Title = book.Title;
            bookInDb.ShortDescription = book.ShortDescription;
            
            var save = await _unitOfWork.Complete();
            if(save > 0)
            {
                return _mapper.Map<BookDto>(bookInDb);
            }
            else
            {
                throw new Exception("There was an issue saving the record to the database");
            }
        }
    }
}
