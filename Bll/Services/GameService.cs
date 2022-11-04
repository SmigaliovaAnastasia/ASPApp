using ASPApp.Common.Dtos;
using ASPApp.Dal.Repository;
using AutoMapper;
using ASPApp.Domain.Entities;
using ASPApp.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using ASPApp.Common.Models.Pagination;

namespace ASPApp.Bll.Services
{
    public class GameService : IGameService
    {
        private readonly IRepository<Game> _repository;
        private readonly IMapper _mapper;

        public GameService(IRepository<Game> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GameDto> CreateGameAsync(GameUpdateDto gameCreateDto)
        {
            var game = _mapper.Map<Game>(gameCreateDto);
            var existanceCheck = await _repository.GetWithFiltersAsync(g => 
                g.Name == game.Name &&
                g.ReleaseDate == game.ReleaseDate);
            if (existanceCheck != null)
            {
                throw new EntryAlreadyExistsException("The game you are trying to add already exists");
            }
            await _repository.AddAsync(game);
            await _repository.SaveChangesAsync();
            return _mapper.Map<GameDto>(game);
        }

        public async Task DeleteGameAsync(Guid id)
        {
            try
            {
                await _repository.RemoveAsync(id);
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ConcurrencyException("The game you are trying to delete was already deleted");
            }
        }

        public async Task<IEnumerable<GameListDto>> GetAllGamesAsync()
        {
            var games = await _repository.GetAllWithIncludeAsync(g => g.ComplexityLevel, z => z.Genres);
            if (games == null || games.Count() == 0)
            {
                throw new EntryNotFoundException("No games found.");
            }
            var gameDtos = _mapper.Map<IEnumerable<Game>, IEnumerable<GameListDto>>(games);
            return gameDtos;
        }

        public async Task<PagedResult<GameListDto>> GetPagedGamesAsync(PagedRequest<Game> request)
        {
            return await _repository.GetPagedResultAsync<GameListDto>(request, _mapper, g => g.Genres, g => g.ComplexityLevel, g => g.GameSeries);
        }

        public async Task<GameDto> GetGameAsync(Guid id)
        {
            var game = await _repository.GetByIdWithIncludeAsync(id, g => g.ComplexityLevel, g => g.Genres, g => g.GameSeries);
            if(game == null)
            {
                throw new EntryNotFoundException("The game you are requesting doesn't exist");
            }
            return _mapper.Map<GameDto>(game);
        }

        public async Task UpdateGameAsync(Guid id, GameUpdateDto gameDto)
        {
            var game = await _repository.GetByIdAsync(id);
            if(game == null)
            {
                throw new EntryNotFoundException("The game you are trying to update doesn't exist");
            }
            _mapper.Map(gameDto, game);
            try
            {
                await _repository.UpdateAsync(game.Id);
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ConcurrencyException("The game you are trying to update was already updated.");
            }
        }
    }
}
