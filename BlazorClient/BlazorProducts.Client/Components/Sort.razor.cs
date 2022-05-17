using Microsoft.AspNetCore.Components;

namespace BlazorProducts.Client.Components
{
    public partial class Sort
    {
        [Parameter]
        public EventCallback<string> onSortChanged { get; set; }

        private async Task ApplySort(ChangeEventArgs eventArgs)
        {
            if (eventArgs.Value.ToString() == "-1")
                return;
            await onSortChanged.InvokeAsync(eventArgs.Value.ToString());
        }

    }
}
