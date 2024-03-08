namespace UnityNexus.Server.Queries.Tags
{
    public record GetAllTagsQuery : IRequest<List<TagModel>>;

    public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, List<TagModel>>
    {
        private readonly ITagStore _tagStore;

        public GetAllTagsQueryHandler(ITagStore tagStore)
        {
            _tagStore = tagStore;
        }

        public async ValueTask<List<TagModel>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            List<Tag> result = await _tagStore.GetAllTagsAsync();
            return result.Select(TagMapper.Map).ToList();
        }
    }
}
