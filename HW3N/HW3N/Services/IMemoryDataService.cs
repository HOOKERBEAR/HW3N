using HW3N.Data;
using HW3N.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HW3N.Services
{

    class IMemoryDataService : IDataService
    {
        public List<Recipe> Recipes;

        public IMemoryDataService()
        {
            Recipes = new List<Recipe>();
        }


        public void addRecipe(Recipe recipe)
        {
            Recipes.Add(recipe);
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return Recipes;
        }

        //for testing, will not be used
        private void CreateIngredientList()
        {
            string[] ingredients;
            Recipe Recipe0 = new Recipe();
        }


    }
}
