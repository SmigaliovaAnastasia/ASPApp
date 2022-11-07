using ASPApp.Common.Models.Pagination;
using ASPApp.Domain.Entities;
using ASPApp.Migrations;
using AutoMapper;
using System.Linq.Expressions;

namespace ASPApp.Dal.Repository.Interfaces
{
    public interface IGameRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        Task<Game?> ConnectRelatedEntities(Guid id, ICollection<Guid> ids);
    }
}
