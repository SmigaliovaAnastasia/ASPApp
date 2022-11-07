using ASPApp.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using ASPApp.Domain.Entities;
using ASPApp.Common.Models.Pagination;
using AutoMapper;
using NuGet.Packaging;
using ASPApp.Dal.Repository.Interfaces;

namespace ASPApp.Dal.Repository.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository<Game>
    {
        private DbContext _context { get; set; }
        public GameRepository(DbContext context) : base(context) 
        { 
            _context = context;
        }

        public async Task<Game?> ConnectRelatedEntities(Guid id, ICollection<Guid> ids)
        {
            var relatedEntities = await _context.Set<Genre>().Where(e => ids.Contains(e.Id)).ToListAsync();
            var entity = await GetByIdWithIncludeAsync(id, g => g.Genres);
            if (entity != null)
            {
                entity.Genres = entity.Genres.Intersect(relatedEntities).ToList();
                entity.Genres.AddRange(relatedEntities.Except(entity.Genres));
            }
            return entity;
        }
    }
}
