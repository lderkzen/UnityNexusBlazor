
namespace UnityNexus.Client.Pages
{
    public partial class Groups
    {
        private ObservableCollection<GroupModel>? _groups;
        private Dictionary<CategoryId, CategoryModel>? _categories;
        private Dictionary<TagId, TagModel>? _tags;

        protected override async Task OnInitializedAsync()
        {
            await LoadGroupsAsync();
        }

        private Task LoadGroupsAsync()
        {
            _categories = [];
            _tags = [];
            _groups = [];

            StateHasChanged();

            _categories.Add(
                CategoryId.From(1),
                new CategoryModel
                {
                    CategoryId = CategoryId.From(1),
                    Name = "Hand of Unity",
                    GroupIds = [GroupId.From(1), GroupId.From(2)]
                }
            );
            _categories.Add(
                CategoryId.From(2),
                new CategoryModel
                {
                    CategoryId = CategoryId.From(2),
                    Name = "Ashes of Creation",
                    GroupIds = [GroupId.From(3), GroupId.From(4)]
                }
            );
            _tags.Add(
                TagId.From(1),
                new TagModel
                {
                    TagId = TagId.From(1),
                    Content = "Min. 25 hrs weekly"
                }
            );
            _tags.Add(
                TagId.From(2),
                new TagModel
                {
                    TagId = TagId.From(2),
                    Content = "Event participation mandatory"
                }
            );
            _groups.Add(new GroupModel
            {
                GroupId = GroupId.From(1),
                CategoryId = CategoryId.From(1),
                Name = "Member",
                Intro = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                Position = 0,
                IsLocked = false,
                Image = "/images/hou_logo_large.png"
            });
            _groups.Add(new GroupModel
            {
                GroupId = GroupId.From(2),
                CategoryId = CategoryId.From(1),
                Name = "Social Member",
                Intro = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                Position = 1,
                IsLocked = false,
                Image = "/images/hou_logo_large.png"
            });
            _groups.Add(new GroupModel
            {
                GroupId = GroupId.From(3),
                CategoryId = CategoryId.From(2),
                Name = "Main guild: Hand of Unity",
                Intro = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                TagIds = [TagId.From(1), TagId.From(2)],
                Position = 2,
                IsLocked = false,
                Image = "/images/hou_logo_large.png"
            });
            _groups.Add(new GroupModel
            {
                GroupId = GroupId.From(4),
                CategoryId = CategoryId.From(2),
                Name = "Social guild: Fellowship of Unity",
                Intro = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                Position = 3,
                IsLocked = true,
                Image = "/images/hou_logo_large.png"
            });


            StateHasChanged();
            return Task.CompletedTask;
        }
    }
}
