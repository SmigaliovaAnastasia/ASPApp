using System.IO;
using ASPApp.Domain.Entities;
using ASPApp.Dal.Repository;
using ASPApp.Common.Dtos;
using ASPApp.Common.Models.Pagination;

namespace ASPApp.Bll.Services
{
    public interface IGameService
    {
        Task<IEnumerable<GameListDto>> GetAllGamesAsync();
        Task<PagedResult<GameListDto>> GetPagedGamesAsync(PagedRequest<Game> request);

        Task<GameDto> GetGameAsync(Guid id);

        Task<GameDto> CreateGameAsync(GameUpdateDto bookForUpdateDto);

        Task UpdateGameAsync(Guid id, GameUpdateDto bookDto);

        Task DeleteGameAsync(Guid id);
    }
}

