namespace ASPApp.Common.Models.Pagination.Filter
{
    public abstract class Filter<T>
    {
        public string FilterProperty { get; set; }
        public char? FilterOperator { get; set; }
        public string Value { get; set; }
        public Filter() {}
        public abstract IQueryable<T> ApplyFilter(IQueryable<T> query);
    }
}
