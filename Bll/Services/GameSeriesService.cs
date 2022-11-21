using ASPApp.Bll.Interfaces;
using ASPApp.Common.Dtos.GameDtos;
using ASPApp.Common.Exceptions;
using ASPApp.Dal.Repository.Interfaces;
using ASPApp.Domain.Entities;
using AutoMapper;

namespace ASPApp.Bll.Services
{
    public class GameSeriesService : IGameSeriesService
    {
        private readonly IRepository<GameSeries> _repository;
        private readonly IMapper _mapper;

        public GameSeriesService(IRepository<GameSeries> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GameSeriesDto>> GetAllGameSeriesAsync()
        {
            var gameSeries = await _repository.GetAllAsync();
            if (gameSeries == null || gameSeries.Count() == 0)
            {
                throw new EntryNotFoundException("No game series found.");
            }
            var gameSeriesDtos = _mapper.Map<IEnumerable<GameSeries>, IEnumerable<GameSeriesDto>>(gameSeries);
            return gameSeriesDtos;
        }

        public async Task<GameSeriesDto> GetGameSeriesAsync(Guid id)
        {
            var gameSeries = await _repository.GetByIdAsync(id);
            if (gameSeries == null)
            {
                throw new EntryNotFoundException("The game series you are requesting doesn't exist");
            }
            return _mapper.Map<GameSeriesDto>(gameSeries);
        }
    }
}
