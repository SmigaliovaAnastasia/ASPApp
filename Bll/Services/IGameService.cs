using System.IO;
using ASPApp.Domain.Entities;
using ASPApp.Dal.Repository;
using ASPApp.Common.Dtos;

namespace ASPApp.Bll.Services
{
    public interface IGameService
    {
        //Task<PaginatedResult<BookListDto>> GetPagedBooks(PagedRequest pagedRequest);

        Task<GameDto> GetGame(int id);

        Task<GameDto> CreateGame(GameUpdateDto bookForUpdateDto);

        Task UpdateGame(int id, GameUpdateDto bookDto);

        Task DeleteGame(int id);
    }
}

