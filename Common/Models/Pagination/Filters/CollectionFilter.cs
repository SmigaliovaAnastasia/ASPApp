using ASPApp.Domain.Entities;

namespace ASPApp.Common.Models.Pagination.Filters
{
    public class CollectionFilter : Filter<Collection>
    {
        public override IQueryable<Collection> ApplyFilter(IQueryable<Collection> query) => FilterProperty switch
        {
            "application_user_id" => query.Where(c => c.ApplicationUserId.ToString() == Value),
            "name" => query.Where(g => g.Name.ToLower().Contains(Value.ToLower())),
            _ => throw new ArgumentException(),
        };
    }
}
