namespace ASPApp.Common.Models.Pagination.SortingMethod
{
    public abstract class SortingMethod<T>
    {
        public string Value { get; set; }

        public SortingMethod() {}
        public abstract IQueryable<T> ApplySorting(IQueryable<T> query);
    }
}
