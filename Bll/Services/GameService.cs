using ASPApp.Common.Dtos;
using ASPApp.Dal.Repository;
using AutoMapper;
using ASPApp.Domain.Entities;

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
            var result = await _repository.AddAsync(game);
            await _repository.SaveChangesAsync();
            return _mapper.Map<GameDto>(game);
        }

        public async Task<bool> DeleteGameAsync(int id)
        {
            var result = await _repository.RemoveAsync(id);
            await _repository.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<GameDto>?> GetAllGamesAsync()
        {
            var games = await _repository.GetAllAsync();
            if (games == null)
            {
                return null;
            }
            var gameDtos = _mapper.Map<IEnumerable<Game>, IEnumerable<GameDto>>(games);
            return gameDtos;
        }

        public async Task<GameDto?> GetGameAsync(int id)
        {
            var game = await _repository.GetByIdAsync(id);
            return game != null ? _mapper.Map<GameDto>(game) : null;
        }

        public async Task<GameDto?> UpdateGameAsync(int id, GameUpdateDto gameDto)
        {
            var game = await _repository.GetByIdAsync(id);
            if(game == null)
            {
                return null;
            }
            _mapper.Map(gameDto, game);
            await _repository.UpdateAsync(game.GameId);
            await _repository.SaveChangesAsync();
            return _mapper.Map<GameDto>(game);
        }
    }
}
