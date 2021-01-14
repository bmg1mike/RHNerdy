using Application.Interfaces;
using Domain;
using Domain.DTOs;
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
        private readonly IBookService _service;
        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _service.GetBooks();
            return Ok(new NerdyResponse { Result = books});
        }

        [HttpGet("GetBookById/{id}", Name ="Details")]
        public async Task<IActionResult> GetBook(string id)
        {
            var book = await _service.GetBookById(id);
            return Ok(new NerdyResponse {Result = book });
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> CreateBook(Book model)
        {
            if (!ModelState.IsValid)
                throw new Exception("Please fill all required properties");

            var book = await _service.CreateBook(model);
            return CreatedAtRoute("Details", new { id = book.Id });
        }

        [HttpPut("UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBook(string id, BookDto model)
        {
            var book = await _service.UpdateBook(id, model);
            return CreatedAtRoute("Details", new { id = book.Id }, book);
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(string id)
        {
            throw new NotImplementedException();
        }
    }
}
