namespace UnityNexus.Shared.Models.Requests
{
    public class PaginationBaseRequest
    {
        public int PageNumber { get; set; } = 1;

        protected virtual int MaxPageSize { get; } = 50;
        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}
