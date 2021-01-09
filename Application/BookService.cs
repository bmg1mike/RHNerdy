using Application.Interfaces;
using AutoMapper;
using Domain.DTOs;
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
        public Task<BookDto> CreateBook(BookDto book)
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> GetBookById(string id)
        {
            throw new NotImplementedException();
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

        public Task<BookDto> UpdateBook(string id, BookDto book)
        {
            throw new NotImplementedException();
        }
    }
}
