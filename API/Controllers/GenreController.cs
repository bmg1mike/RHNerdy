using Application.Interfaces;
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
        private readonly IGenreService _service;
        public GenreController(IGenreService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllGenre()
        {
            var genres = await _service.GetGenres();
            return Ok(new NerdyResponse { Result = genres });
        }

        [HttpGet("{id}", Name ="GenreDetails")]
        public async Task<IActionResult> GetGenre(string id)
        {
            var genre = await _service.GetGenreById(id);
            return Ok(new NerdyResponse { Result = genre });
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateGenre(Genre model)
        {
            var genre = await _service.CreateGenre(model);
            
            return CreatedAtRoute("GenreDetails", new { id = genre.Id },genre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(string id, Genre model)
        {
            var genre = await _service.UpdateGenre(id, model);
            return CreatedAtRoute("GenreDetails", new { id = genre.Id }, genre);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(string id)
        {
            await _service.DeleteGenre(id);
            return Ok();
        }
    }
}
