using HW3N.Data;
using HW3N.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace HW3N.ViewModels
{
    public class RecipeDetailPageViewModel : ViewModelBase
    {
        private readonly IDataService dataService;
        private readonly INavigationService navigationService;
        private readonly IPageDialogService pageDialogService;
        private Recipe _recipe;
        private string RecipeName;

        public IEnumerable<Recipe> recipeList { get; set; }
        public RecipeDetailPageViewModel(INavigationService navigationService, IDataService dataService, IPageDialogService pageDialogService)
            : base(navigationService)
        {
            this.navigationService = navigationService;
            this.pageDialogService = pageDialogService;
            _recipe = new Recipe();

            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));

        }

        public override void OnNavigatedTo(INavigationParameters parameters) {
            _recipe = (Recipe)parameters["recipe"];

            RecipeName = _recipe.Name;
            RecipeId = _recipe.Id;
        }

        private int recipeId;
        public int RecipeId
        {
            get => recipeId;
            set { SetProperty(ref recipeId, value); }
        }

    }
    
}
