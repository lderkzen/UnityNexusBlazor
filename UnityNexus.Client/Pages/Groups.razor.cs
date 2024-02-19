
namespace UnityNexus.Client.Pages
{
    public partial class Groups
    {
        private ObservableCollection<GroupModel>? _groups;
        private Dictionary<int, CategoryModel>? _categories;
        private Dictionary<int, TagModel>? _tags;

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
                1,
                new CategoryModel
                {
                    Id = 1,
                    Name = "Hand of Unity",
                    GroupIds = [1, 2]
                }
            );
            _categories.Add(
                2,
                new CategoryModel
                {
                    Id = 2,
                    Name = "Ashes of Creation",
                    GroupIds = [3, 4]
                }
            );
            _tags.Add(
                1,
                new TagModel
                {
                    Id = 1,
                    Content = "Min. 25 hrs weekly"
                }
            );
            _tags.Add(
                2,
                new TagModel
                {
                    Id = 2,
                    Content = "Event participation mandatory"
                }
            );
            _groups.Add(new GroupModel {
                Id = 1,
                CategoryId = 1,
                Title = "Member",
                Intro = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                Position = 0,
                IsLocked = false,
                Image = "/images/hou_logo_large.png"
            });
            _groups.Add(new GroupModel
            {
                Id = 2,
                CategoryId = 1,
                Title = "Social Member",
                Intro = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                Position = 1,
                IsLocked = false,
                Image = "/images/hou_logo_large.png"
            });
            _groups.Add(new GroupModel
            {
                Id = 3,
                CategoryId = 2,
                Title = "Main guild: Hand of Unity",
                Intro = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
                TagIds = [1, 2],
                Position = 2,
                IsLocked = false,
                Image = "/images/hou_logo_large.png"
            });
            _groups.Add(new GroupModel
            {
                Id = 4,
                CategoryId = 2,
                Title = "Social guild: Fellowship of Unity",
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
