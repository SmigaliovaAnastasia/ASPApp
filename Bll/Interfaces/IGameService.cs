using System.IO;
using ASPApp.Domain.Entities;
using ASPApp.Dal.Repository;
using ASPApp.Common.Models.Pagination;
using ASPApp.Common.Dtos.GameDtos;

namespace ASPApp.Bll.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<GameListDto>> GetAllGamesAsync();
        Task<PagedResult<GameListDto>> GetPagedGamesAsync(PagedRequest<Game> request);

        Task<GameDto> GetGameAsync(Guid id);

        Task<GameDto> CreateGameAsync(GameUpdateDto gameUpdateDto);

        Task UpdateGameAsync(Guid id, GameUpdateDto gameDto);

        Task DeleteGameAsync(Guid id);
    }
}

