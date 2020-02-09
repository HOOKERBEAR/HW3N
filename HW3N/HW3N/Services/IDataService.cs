using HW3N.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HW3N.Services
{
    public interface IDataService
    {
        void addRecipe(Recipe recipe);

         IEnumerable<Recipe> GetRecipes();

        void Delete();

    }
}
