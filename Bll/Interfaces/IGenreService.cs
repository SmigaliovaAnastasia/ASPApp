using ASPApp.Common.Dtos.CollectionDtos;
using ASPApp.Common.Dtos.GameDtos;
using ASPApp.Common.Models.Pagination;

namespace ASPApp.Bll.Interfaces
{
    public interface IGenreService
    {
        Task<GenreDto> GetGenreAsync(Guid id);
        Task<IEnumerable<GenreDto>> GetAllGenresAsync();
    }
}
