using HomebreweryShoppingAssistaint.Enums;
using HomebreweryShoppingAssistaint.Models;
using HomebreweryShoppingAssistaintClient.Components.Dialog;
using MudBlazor;

namespace HomebreweryShoppingAssistaintClient.Components.Pages.BatchesManager
{
    public partial class Fermenters
    {
        private string Title = "Zbiorniki fermentacyjne";
        private Fermenter[]? fermenters;

        bool isDoubledAfterChange;
        int tabToStay = 0;
        int tabToGo = 0;
        bool hasUnsavedChanges = false;

        MudTabs tabs;


        protected override async Task OnInitializedAsync()
        {
            // Simulate asynchronous loading to demonstrate streaming rendering
            await Task.Delay(500);

            var startDate = DateOnly.FromDateTime(DateTime.Now);
            var names = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
            var types = new[] { EnumFermenterType.PlasticBucket, EnumFermenterType.GlassJar, EnumFermenterType.CorneliusKeg, EnumFermenterType.PetainerKeg };
            fermenters = Enumerable.Range(1, 10).Select(index => new Fermenter
            {
                Number = index,
                StartDate = startDate.AddDays(index),
                Name = names[Random.Shared.Next(names.Length)],
                Type = types[Random.Shared.Next(types.Length)]
            }).ToArray();
        }

        private void OpenDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<DefaultDialog>("Czy chcesz zmienić zakładkę bez zapisywania?", options);
        }

        private async void OnActiveTabIndexChanged()
        {
            if (isDoubledAfterChange)
            {
                isDoubledAfterChange = false;
            }
            else
            {
                //isDoubledAfterChange = true;
                //tabs.ActivePanelIndex = tabToStay;
            }
            if (hasUnsavedChanges)
            {
                isDoubledAfterChange = true;
                tabs.ActivePanelIndex = tabToStay;

                if (hasUnsavedChanges)
                //&& !await ShowWarning("Czy chcesz zmienić zakładkę bez zapisania zmian? Zmiany na opuszczanej zakładce zostaną utracone."))
                {
                    OpenDialog();
                    isDoubledAfterChange = true;
                    tabs.ActivePanelIndex = tabToStay;
                }
                else
                {
                    //isAfterChange = true;
                    tabToStay = tabs.ActivePanelIndex;
                    //tabs.ActivePanelIndex = tabToGo;
                    hasUnsavedChanges = false;
                }

                //isDoubledAfterChange = true;
            }
            else
            {
                OpenDialog();
                //isAfterChange = true;
                tabToStay = tabs.ActivePanelIndex;
                //tabs.ActivePanelIndex = tabToGo;
                hasUnsavedChanges = false;

                //tabToGo = tabs.ActivePanelIndex;

                ////zeby nie przeskoczyl przed pytaniem, alw wywoluje changed
                //if (isDoubledAfterChange)
                //{
                //    //isDoubledAfterChange = true;
                //    tabs.ActivePanelIndex = tabToStay;
                //}
                //else
                //{
                //    //isDoubledAfterChange = true;
                //    tabs.ActivePanelIndex = tabToGo;
                //}

                //if (hasUnsavedChanges
                //    && !await ShowWarning("Czy chcesz zmienić zakładkę bez zapisania zmian? Zmiany na opuszczanej zakładce zostaną utracone."))
                //{
                //    //isDoubledAfterChange = true;
                //    tabs.ActivePanelIndex = tabToStay;
                //}
                //else
                //{
                //    //isAfterChange = true;
                //    tabToStay = tabs.ActivePanelIndex;
                //    //tabs.ActivePanelIndex = tabToGo;
                //    hasUnsavedChanges = false;
                //}

                //isDoubledAfterChange = true;
            }
        }
    }
}