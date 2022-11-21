using ASPApp.Common.Dtos.GameDtos;

namespace ASPApp.Bll.Interfaces
{
    public interface IGameSeriesService
    {
        Task<GameSeriesDto> GetGameSeriesAsync(Guid id);
        Task<IEnumerable<GameSeriesDto>> GetAllGameSeriesAsync();
    }
}
