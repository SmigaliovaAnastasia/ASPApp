using ASPApp.Common.Dtos.CollectionDtos;
using ASPApp.Common.Dtos.ReviewDtos;
using ASPApp.Common.Models.Pagination;
using ASPApp.Domain.Entities;

namespace ASPApp.Bll.Interfaces
{
    public interface ICollectionService
    {
        Task<PagedResult<CollectionDto>> GetPagedCollectionsAsync(PagedRequest<Collection> request);

        Task<CollectionDto> GetCollectionAsync(Guid id);

        Task<CollectionDto> CreateCollectionAsync(CollectionCreateDto collectionCreateDto);

        Task UpdateCollectionAsync(Guid id, CollectionUpdateDto collectionUpdateDto);

        Task DeleteCollectionAsync(Guid id);
    }
}
