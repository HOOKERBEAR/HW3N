using HW3N.Data;
using HW3N.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HW3N.ViewModels
{
    public class EditRecipeViewModel : ViewModelBase
    {
        private readonly IDataService dataService;
        private readonly INavigationService navigationService;
        private readonly IPageDialogService pageDialogService;
        public IEnumerable<Recipe> recipeList { get; set; }
        public EditRecipeViewModel(INavigationService navigationService, IDataService dataService, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            Title = "Edit Recipe";
            this.navigationService = navigationService;
            this.pageDialogService = pageDialogService;

            Recipe recipe = new Recipe();

            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));

            dataService.addRecipe(recipe);
            recipeList = dataService.GetRecipes();

          
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            recipe = (Recipe)parameters["recipe"];
            RecipeName = recipe.Name;
            RecipeId = recipe.Id;
            Ingredients = dataService.GetIngredients(recipe);
        }

        var answer = TestableDialog.TestableDisplayAlertAsync(pageDialogService, "Return?", "Would you like to go back to the last page?", "Yes", "No");
            if (answer)
            {
                 TestableNavigation.TestableGoBackAsync(navigationService);
            }

    private Command returnToMain;
        public Command Recipe => returnToMain ?? (returnToMain = new Command(async () =>
        {
            NavigationParameters Parameters = new NavigationParameters();
            await TestableNavigation.TestableNavigateAsync(NavigationService, nameof(HW3N.Views.MainPage, Parameters, false, true).ConfigureAwait(false);
        }));


    }

}





//private Command addRecipe;
//public Command AddRecipe => addRecipe ?? (addRecipe = new Command(async () =>
//{
//    NavigationParameters Parameters = new NavigationParameters();
//    await TestableNavigation.TestableNavigateAsync(NavigationService, nameof(HW3N.Views.AddRecipe), Parameters, false, true).ConfigureAwait(false);
//}));
