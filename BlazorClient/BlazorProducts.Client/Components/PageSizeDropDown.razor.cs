using Microsoft.AspNetCore.Components;

namespace BlazorProducts.Client.Components
{
    public partial class PageSizeDropDown
    {
        [Parameter]
        public EventCallback<int> SelectedPageSize { get; set; }

        private async Task onPageSizeChange(ChangeEventArgs eventArgs)
        {
            await SelectedPageSize.InvokeAsync(Int32.Parse(eventArgs.Value.ToString()));
        }
    }
}
