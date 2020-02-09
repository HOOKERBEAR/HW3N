using HW3N.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Polly;

namespace HW3N.Services
{
    public class SQLiteDataService : IDataService
    {

        public SQLiteDataService()
        {
            var _databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SqliteDatabase.db3");
            db = new SQLiteConnection(_databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache | SQLiteOpenFlags.Create);
            db.CreateTable<Recipe>();
            db.CreateTable<Ingredients>();
        }

        

        private SQLiteConnection db;

        public void addRecipe(Recipe recipe)
        {
            db.Insert(recipe);
            
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return db.Table<Recipe>().ToList();
        }

        public void Delete() {

            db.DeleteAll<Recipe>();
        }
    }

}