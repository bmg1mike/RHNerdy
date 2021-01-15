using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GenreService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GenreDto> CreateGenre(Genre model)
        {
            var genreInDb = await _unitOfWork.Genre.Create(model);
            var result = await _unitOfWork.Complete();
            if (result > 0)
            {
                return _mapper.Map<GenreDto>(genreInDb);
            }
            else
            {
                throw new Exception("There was a problem saving this Genre to the database");
            }
        }

        public async Task<GenreDto> GetGenreById(string id)
        {
            var genreInDb = await _unitOfWork.Genre.GetByIdAsync(id);
            if(genreInDb == null)
            {
                throw new Exception("There is no Genre with the Id: " + id);
            }
            var genre = _mapper.Map<GenreDto>(genreInDb);
            return genre;

        }

        public async Task<List<GenreDto>> GetGenres()
        {
            var genreInDb = await _unitOfWork.Genre.ListAllAsync();
            var genre = new List<GenreDto>();
            foreach (var item in genreInDb)
            {
                genre.Add(_mapper.Map<GenreDto>(item));
            }
            return genre;
        }

        public async Task<GenreDto> UpdateGenre(string id, Genre model)
        {
            var genreInDb = await _unitOfWork.Genre.GetByIdAsync(id);
            genreInDb.GenreName = model.GenreName;
            genreInDb.DateModified = DateTime.Now;
            var result = await _unitOfWork.Complete();
            if (result > 0)
            {
                return _mapper.Map<GenreDto>(genreInDb);
            }
            else
            {
                throw new Exception("There was a problem updating the Genre in the database with Id: " + id);
            }
        }

        public async Task DeleteGenre(string id)
        {
            await _unitOfWork.Genre.Delete(id);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
            {
                throw new Exception("There was a problem deleting this Genre from the database");
            }
            
        }
    }
}
