using ASPApp.Common.Dtos;
using ASPApp.Dal.Repository;
using AutoMapper;
using ASPApp.Domain.Entities;
using ASPApp.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

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
        public async Task<GameDto?> CreateGameAsync(GameUpdateDto gameCreateDto)
        {
            var game = _mapper.Map<Game>(gameCreateDto);
            var existanceCheck = await _repository.GetWithFilter(g => 
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

        public async Task DeleteGameAsync(int id)
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

        public async Task<IEnumerable<GameDto>?> GetAllGamesAsync()
        {
            var games = await _repository.GetAllAsync();
            if (games == null)
            {
                throw new EntryNotFoundException("No games found.");
            }
            var gameDtos = _mapper.Map<IEnumerable<Game>, IEnumerable<GameDto>>(games);
            return gameDtos;
        }

        public async Task<GameDto?> GetGameAsync(int id)
        {
            var game = await _repository.GetByIdAsync(id);
            if(game == null)
            {
                throw new EntryNotFoundException("The game you are requesting doesn't exist");
            }
            return _mapper.Map<GameDto>(game);
        }

        public async Task UpdateGameAsync(int id, GameUpdateDto gameDto)
        {
            var game = await _repository.GetByIdAsync(id);
            if(game == null)
            {
                throw new EntryNotFoundException("The game you are trying to update doesn't exist");
            }
            _mapper.Map(gameDto, game);
            try
            {
                await _repository.UpdateAsync(game.GameId);
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ConcurrencyException("The game you are trying to update was already updated.");
            }
        }
    }
}
