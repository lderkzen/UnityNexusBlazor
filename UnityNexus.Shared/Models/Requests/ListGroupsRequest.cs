namespace UnityNexus.Shared.Models.Requests
{
    public class ListGroupsRequest : PaginationBaseRequest
    {
        public string? Filter { get; set; }
    }
}
