using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IGenreService
    {
        Task<List<GenreDto>> GetGenres();
        Task<GenreDto> GetGenreById(string id);
        Task<GenreDto> CreateGenre(Genre model);
        Task<GenreDto> UpdateGenre(string id, Genre model);
        Task DeleteGenre(string id);


    }
}
