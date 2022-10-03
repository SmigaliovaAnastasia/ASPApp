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
        public async Task CreateGameAsync(GameUpdateDto gameCreateDto)
        {
            var game = _mapper.Map<Game>(gameCreateDto);
            await _repository.AddAsync(game);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(int id)
        {
            await _repository.RemoveAsync(id);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<GameDto>?> GetAllGames()
        {
            var games = await _repository.GetAllAsync();
            if(games == null)
            {
                return null;
            }
            var gameDtos = _mapper.Map<IEnumerable<Game>, IEnumerable<GameDto>>(games);
            return gameDtos;
        }

        public async Task<GameDto> GetGameAsync(int id)
        {
            var game = await _repository.GetByIdAsync(id);
            if(game == null)
            {
                throw new ArgumentNullException();
            }
            var gameDto = _mapper.Map<GameDto>(game);
            return gameDto;
        }

        public async Task UpdateGameAsync(int id, GameUpdateDto gameDto)
        {
            var game = await _repository.GetByIdAsync(id);
            _mapper.Map(gameDto, game);
            await _repository.SaveChangesAsync();
        }
    }
}
