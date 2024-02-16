using UnityNexus.Shared.Extensions;

namespace UnityNexus.Shared.Models.Responses
{
    public class PaginationBaseResponse<TItem>
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PageSize { get; set; }

        public int TotalCount { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;

        public TItem[] Items { get; set; }

        protected PaginationBaseResponse()
        {
            CurrentPage = 1;
            PageSize = 1;
            TotalPages = 1;
            TotalCount = 0;
            Items = [];
        }

        protected PaginationBaseResponse(
            TItem[] items,
            int currentPage,
            int pageSize,
            int totalCount
        )
        {
            Items = items.IfNotNull();

            ArgumentOutOfRangeException.ThrowIfLessThan(currentPage, 1);
            ArgumentOutOfRangeException.ThrowIfLessThan(pageSize, 1);
            ArgumentOutOfRangeException.ThrowIfNegative(totalCount);

            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }
    }
}
