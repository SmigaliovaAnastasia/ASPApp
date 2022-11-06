using ASPApp.Common.Exceptions;
using ASPApp.Common.Models.Pagination;
using ASPApp.Domain.Entities;
using System.Drawing.Printing;
using System.Net;

namespace ASPApp.Common.Models.Pagination.GamePagination
{
    public class GamePagedRequest : PagedRequest<Game>
    {
        public GamePagedRequest()
        {
            SortingMethod = new GameSortingMethod();
            Filters = new List<GameFilter>();
        }
    }
}
