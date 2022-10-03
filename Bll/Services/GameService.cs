using ASPApp.Common.Dtos;
using ASPApp.Dal.Repository;
using AutoMapper;

namespace ASPApp.Bll.Services
{
    public class GameService : IGameService
    {
        public Task<GameDto> CreateGame(GameUpdateDto bookForUpdateDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGame(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GameDto> GetGame(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGame(int id, GameUpdateDto bookDto)
        {
            throw new NotImplementedException();
        }
    }
}
