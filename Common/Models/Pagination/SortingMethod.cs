namespace ASPApp.Common.Models.Pagination
{
    public abstract class SortingMethod<T>
    {
        public string Value { get; set; }

        public SortingMethod() { }
        public abstract IQueryable<T> ApplySorting(IQueryable<T> query);
    }
}
