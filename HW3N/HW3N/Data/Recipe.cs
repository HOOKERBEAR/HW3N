using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace HW3N.Data
{
    public class Recipe
    {

        public Recipe()
        {
            this.Id = 1;
            this.Name = "cake";

            int[] array = new int[] { 1, 2, 3, 4 };
            List<int> list = new List<int>();
            list.AddRange(array);
            this.IngredientID = list;
            this.Instructions = "bake 9000 degrees";
        }
        public Recipe(int Id, string Name, List<int> ingredientID, string Instructions)
        {
            this.Id = Id;
            if (Name.Length < 5)
            {
                throw new Exception("Name is too short");
            }
            else
            {
                this.Name = Name;
            }
            if (ingredientID.Count == 0)
            {
                throw new Exception("You can't have <1 ingredients, dude!");
            }
            else
            {
                this.IngredientID = ingredientID;
            }

            this.Instructions = Instructions;
        }



        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Instructions { get; set; }
        [OneToMany(CascadeOperations=CascadeOperation.All)]
        public List<int> IngredientID { get; set; }
    }
}
