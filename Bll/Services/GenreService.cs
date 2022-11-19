using ASPApp.Bll.Interfaces;
using ASPApp.Common.Dtos.GameDtos;
using ASPApp.Common.Exceptions;
using ASPApp.Common.Models.Pagination;
using ASPApp.Dal.Repository.Interfaces;
using ASPApp.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ASPApp.Bll.Services
{
    public class GenreService : IGenreService
    {
        private readonly IRepository<Genre> _repository;
        private readonly IMapper _mapper;

        public GenreService(IRepository<Genre> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GenreDto>> GetAllGenresAsync()
        {
            var genres = await _repository.GetAllAsync();
            if (genres == null || genres.Count() == 0)
            {
                throw new EntryNotFoundException("No genres found.");
            }
            var genreDtos = _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDto>>(genres);
            return genreDtos;
        }

        public async Task<GenreDto> GetGenreAsync(Guid id)
        {
            var genre = await _repository.GetByIdAsync(id);
            if (genre == null)
            {
                throw new EntryNotFoundException("The genre you are requesting doesn't exist");
            }
            return _mapper.Map<GenreDto>(genre);
        }
    }
}
