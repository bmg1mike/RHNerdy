using Domain;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BookController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _unitOfWork.Book.ListAllAsync();
            return Ok(new NerdyResponse { Result = books});
        }

        [HttpGet("GetBookById/{id}", Name ="Details")]
        public async Task<IActionResult> GetBook(string id)
        {
            var book = await _unitOfWork.Book.GetByIdAsync(id);
            return Ok(new NerdyResponse {Result = book });
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> CreateBook(Book model)
        {
            var book = await _unitOfWork.Book.Create(model);
            return CreatedAtRoute("Details", new { id = book.Id });
        }

        [HttpPut("UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBook(string id, Book book)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            throw new NotImplementedException();
        }
    }
}
