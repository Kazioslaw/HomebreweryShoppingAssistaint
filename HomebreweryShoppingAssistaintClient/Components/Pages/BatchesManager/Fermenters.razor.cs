using HomebreweryShoppingAssistaintClient.Components.Dialog;
using HomebreweryShoppingAssistant.Models;
using MudBlazor;

namespace HomebreweryShoppingAssistaintClient.Components.Pages.BatchesManager
{
	public partial class Fermenters
	{
		private string Title = "Zbiorniki fermentacyjne";
		private Fermenter[]? Model;

		bool isDoubledAfterChange;
		int tabToStay = 0;
		int tabToGo = 0;
		bool hasUnsavedChanges = false;

		MudTabs tabs;


		protected override async Task OnInitializedAsync()
		{
			// Simulate asynchronous loading to demonstrate streaming rendering
			await Task.Delay(500);

			var fermenters = await FermenterService.GetAllAsync();

			if (fermenters != null && fermenters.Any())
			{
				Model = fermenters.ToArray();
			}
			else
			{
				Console.WriteLine("No fermenters found.");
			}
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