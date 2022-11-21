namespace ASPApp.Common.Models.Pagination
{
    public abstract class SortingMethod<T>
    {
        public string SortingColumn { get; set; }
        public string? Direction { get; set; }

        public SortingMethod() { }
        public abstract IQueryable<T> ApplySorting(IQueryable<T> query);
    }
}
