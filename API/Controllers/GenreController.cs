using AutoMapper;
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
    public class GenreController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GenreController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllGenre()
        {
            var genres = await _unitOfWork.Genre.ListAllAsync();
            return Ok(new NerdyResponse { Result = genres });
        }

        [HttpGet("{id}", Name ="GenreDetails")]
        public async Task<IActionResult> GetGenre(string id)
        {
            var genre = await _unitOfWork.Genre.GetByIdAsync(id);
            return Ok(new NerdyResponse { Result = _mapper.Map<GenreDto>(genre) });
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateGenre(Genre model)
        {
            var genre = await _unitOfWork.Genre.Create(model);
            var result = 
            await _unitOfWork.Complete();
            return CreatedAtRoute("GenreDetails", new { id = genre.Id },genre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(string id, Genre model)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(string id)
        {
            throw new NotImplementedException();
        }
    }
}
