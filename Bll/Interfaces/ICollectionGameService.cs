using ASPApp.Common.Dtos.CollectionDtos;
using ASPApp.Common.Dtos.CollectionGameDtos;
using ASPApp.Common.Models.Pagination;
using ASPApp.Domain.Entities;

namespace ASPApp.Bll.Interfaces
{
    public interface ICollectionGameService
    {
        Task<PagedResult<CollectionGameDto>> GetPagedCollectionsGamesAsync(PagedRequest<CollectionGame> request);

        Task<CollectionGameDto> GetCollectionGameAsync(Guid id);

        Task<CollectionGameDto> CreateCollectionGameAsync(CollectionGameCreateDto collectionGameCreateDto);

        Task UpdateCollectionGameAsync(Guid id, CollectionGameUpdateDto collectionGameUpdateDto);

        Task DeleteCollectionGameAsync(Guid id);
    }
}

