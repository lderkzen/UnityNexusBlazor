namespace UnityNexus.Shared.Models.Responses
{
    public class ListGroupsResponse : PaginationBaseResponse<GroupModel>
    {
        public string? Filter { get; set; }

        public ListGroupsResponse()
        {
        }

        public ListGroupsResponse(
            GroupModel[] items,
            string? filter,
            int currentPage,
            int pageSize,
            int totalCount
        ) : base(items, currentPage, pageSize, totalCount)
        {
            Filter = filter;
        }
    }
}
