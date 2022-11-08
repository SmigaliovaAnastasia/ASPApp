using ASPApp.Bll.Interfaces;
using ASPApp.Common.Dtos.CollectionDtos;
using ASPApp.Common.Dtos.ReviewDtos;
using ASPApp.Common.Exceptions;
using ASPApp.Common.Models.Pagination;
using ASPApp.Dal.Repository.Interfaces;
using ASPApp.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ASPApp.Bll.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly IRepository<Collection> _repository;
        private readonly IMapper _mapper;

        public CollectionService(IRepository<Collection> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CollectionDto> CreateCollectionAsync(CollectionCreateDto collectionCreateDto)
        {
            var collection = _mapper.Map<Collection>(collectionCreateDto);
            var existanceCheck = await _repository.GetWithFiltersAsync(e =>
                e.Name == collection.Name &&
                e.ApplicationUserId == collection.ApplicationUserId);
            if (existanceCheck != null)
            {
                throw new EntryAlreadyExistsException("The collection you are trying to add already exists");
            }
            await _repository.AddAsync(collection);
            await _repository.SaveChangesAsync();
            return _mapper.Map<CollectionDto>(collection);
        }

        public async Task DeleteCollectionAsync(Guid id)
        {
            try
            {
                await _repository.RemoveAsync(id);
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ConcurrencyException("The collection you are trying to delete was already deleted");
            }
        }

        public async Task<PagedResult<CollectionDto>> GetPagedCollectionsAsync(PagedRequest<Collection> request)
        {
            return await _repository.GetPagedResultAsync<CollectionDto>(request, _mapper, e => e.CollectionGames);
        }

        public async Task<CollectionDto> GetCollectionAsync(Guid id)
        {
            var collection = await _repository.GetByIdWithIncludeAsync(id, e => e.ApplicationUserId, e => e.CollectionGames);
            if (collection == null)
            {
                throw new EntryNotFoundException("The collection you are requesting doesn't exist");
            }
            return _mapper.Map<CollectionDto>(collection);
        }

        public async Task UpdateCollectionAsync(Guid id, CollectionUpdateDto collectionUpdateDto)
        {
            var collection = await _repository.GetByIdAsync(id);
            if (collection == null)
            {
                throw new EntryNotFoundException("The collection you are trying to update doesn't exist");
            }
            _mapper.Map(collectionUpdateDto, collection);
            try
            {
                await _repository.UpdateAsync(collection.Id);
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ConcurrencyException("The collection you are trying to update was already updated.");
            }
        }
    }
}
