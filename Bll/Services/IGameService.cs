using System.IO;
using ASPApp.Domain.Entities;
using ASPApp.Dal.Repository;
using ASPApp.Common.Dtos;

namespace ASPApp.Bll.Services
{
    public interface IGameService
    {
        Task<IEnumerable<GameDto>?> GetAllGames();

        Task<GameDto> GetGameAsync(int id);

        Task CreateGameAsync(GameUpdateDto bookForUpdateDto);

        Task UpdateGameAsync(int id, GameUpdateDto bookDto);

        Task DeleteGameAsync(int id);
    }
}

