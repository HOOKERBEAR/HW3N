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
    public class AddRecipeViewModel : BindableBase
    {
        private readonly INavigationService navigationService;
        private readonly IDataService dataService;
        private readonly IPageDialogService pageDialogService;


        public AddRecipeViewModel(INavigationService navigationService, IDataService dataService, IPageDialogService pageDialogService)
        {
            this.navigationService = navigationService;
            this.dataService = dataService;
            this.pageDialogService = pageDialogService;
        }


        private Command add;

        public Command Add => add ?? (add = new Command(async () =>
        {



            //dataService.addRecipe(recipe);
        }));
    }
}
