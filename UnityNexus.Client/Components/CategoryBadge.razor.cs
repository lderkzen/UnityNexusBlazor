namespace UnityNexus.Client.Components
{
    public partial class CategoryBadge
    {
        private Dictionary<int, CategoryModel>? _categories;

        [Parameter]
        public int? CategoryId { get; set; }

        [Parameter]
        public CategoryModel? Model { get; set; }


        protected override async Task OnParametersSetAsync()
        {
            await LoadCategoriesAsync();

            if (CategoryId is not null && Model is null)
                Model = _categories![(int)CategoryId];

            if (Model is null)
                return;

            StateHasChanged();
        }

        private Task LoadCategoriesAsync()
        {
            _categories = [];
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

            StateHasChanged();
            return Task.CompletedTask;
        }
    }
}
