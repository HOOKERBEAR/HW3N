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
using Prism.Behaviors;

namespace HW3N.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IDataService dataService;
        private readonly INavigationService navigationService;
        private readonly IPageDialogService pageDialogService;

        public IEnumerable<Recipe> recipeList { get; set; }
        public MainPageViewModel(INavigationService navigationService, IDataService dataService, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            Title = "Main Page";
            this.navigationService = navigationService;
            this.pageDialogService = pageDialogService;
            //string[] array = new string[] { "1 cup flower", "1 cup sugar", "1 cup animal blood" };
            //List<string> list= new List<string>();
            //list.AddRange(array);
            Recipe recipe= new Recipe();

            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));

            dataService.addRecipe(recipe);
            recipeList = dataService.GetRecipes();

        }
        private Command addRecipe;
        public Command AddRecipe => addRecipe ?? (addRecipe = new Command(async () =>
        {
            NavigationParameters Parameters = new NavigationParameters();
            await TestableNavigation.TestableNavigateAsync(NavigationService, nameof(HW3N.Views.AddRecipe), Parameters, false, true).ConfigureAwait(false);
        }));

        private Command editRecipe;
        public Command EditRecipe => editRecipe ?? (editRecipe = new Command(async () =>
        {
            NavigationParameters Parameters = new NavigationParameters();
            await TestableNavigation.TestableNavigateAsync(NavigationService, nameof(HW3N.Views.EditRecipe), Parameters, false, true).ConfigureAwait(false);
        }));

        private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            NavigationParameters Parameters = new NavigationParameters("Stuff To Say");
            TestableNavigation.TestableNavigateAsync(NavigationService, nameof(HW3N.Views.RecipeDetailPage), Parameters, false, true).ConfigureAwait(false);
        }

        private DelegateCommand<Recipe> itemTappedCommand;

        public DelegateCommand<Recipe> ItemTappedCommand => itemTappedCommand ?? (itemTappedCommand = new DelegateCommand<Recipe>(ExecuteItemTappedCommand));

        public void ExecuteItemTappedCommand(Recipe selectedRecipe) 
        {
            NavigationParameters Parameters = new NavigationParameters();
            Parameters.Add("recipe", selectedRecipe);
            TestableNavigation.TestableNavigateAsync(NavigationService, nameof(HW3N.Views.RecipeDetailPage), Parameters, false, true).ConfigureAwait(false);

        }



    }
}
