using ASPApp.Bll.Interfaces;
using ASPApp.Common.Dtos.CollectionDtos;
using ASPApp.Common.Dtos.CollectionGameDtos;
using ASPApp.Common.Exceptions;
using ASPApp.Common.Models.Pagination;
using ASPApp.Dal.Repository.Interfaces;
using ASPApp.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ASPApp.Bll.Services
{
    public class CollectionGameService : ICollectionGameService
    {
        private readonly IRepository<CollectionGame> _repository;
        private readonly IMapper _mapper;

        public CollectionGameService(IRepository<CollectionGame> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CollectionGameDto> CreateCollectionGameAsync(CollectionGameCreateDto collectionGameCreateDto)
        {
            var collectionGame = _mapper.Map<CollectionGame>(collectionGameCreateDto);
            var existanceCheck = await _repository.GetWithFiltersAsync(e =>
                e.CollectionId == collectionGame.CollectionId &&
                e.GameId == collectionGame.GameId);
            if (existanceCheck != null)
            {
                throw new EntryAlreadyExistsException("The entity you are trying to add already exists");
            }
            await _repository.AddAsync(collectionGame);
            await _repository.SaveChangesAsync();
            return _mapper.Map<CollectionGameDto>(collectionGame);
        }

        public async Task DeleteCollectionGameAsync(Guid id)
        {
            try
            {
                await _repository.RemoveAsync(id);
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ConcurrencyException("The entity you are trying to delete was already deleted");
            }
        }

        public async Task<PagedResult<CollectionGameDto>> GetPagedCollectionsGamesAsync(PagedRequest<CollectionGame> request)
        {
            return await _repository.GetPagedResultAsync<CollectionGameDto>(request, _mapper, e => e.Game);
        }

        public async Task<CollectionGameDto> GetCollectionGameAsync(Guid id)
        {
            var collectionGame = await _repository.GetByIdWithIncludeAsync(id, e => e.Game, e => e.Collection);
            if (collectionGame == null)
            {
                throw new EntryNotFoundException("The collection you are requesting doesn't exist");
            }
            return _mapper.Map<CollectionGameDto>(collectionGame);
        }

        public async Task UpdateCollectionGameAsync(Guid id, CollectionGameUpdateDto collectionGameUpdateDto)
        {
            var collectionGame = await _repository.GetByIdAsync(id);
            if (collectionGame == null)
            {
                throw new EntryNotFoundException("The entity you are trying to update doesn't exist");
            }
            _mapper.Map(collectionGameUpdateDto, collectionGame);
            try
            {
                await _repository.UpdateAsync(collectionGame.Id);
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ConcurrencyException("The entity you are trying to update was already updated.");
            }
        }
    }
}
