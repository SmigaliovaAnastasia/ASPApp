using System.IO;
using ASPApp.Domain.Entities;
using ASPApp.Dal.Repository;
using ASPApp.Common.Dtos;

namespace ASPApp.Bll.Services
{
    public interface IGameService
    {
        Task<IEnumerable<GameListDto>> GetAllGamesAsync();

        Task<GameDto> GetGameAsync(Guid id);

        Task<GameDto> CreateGameAsync(GameUpdateDto bookForUpdateDto);

        Task UpdateGameAsync(Guid id, GameUpdateDto bookDto);

        Task DeleteGameAsync(Guid id);
    }
}

