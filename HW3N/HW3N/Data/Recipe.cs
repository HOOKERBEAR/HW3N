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
            this.Name = "cakes";

            Ingredients in1 = new Ingredients(1, "Eggs", 10, "Cups");
            Ingredients in2 = new Ingredients(2, "Flour", 3, "Almonds");
            Ingredients in3 = new Ingredients(3, "Baking Soda", 1000, "Teaspoons");
            Ingredients in4 = new Ingredients(4, "Milk", 30, "Liters");

            Ingredients[] array = new Ingredients[] { in1, in2, in3, in4 };
            List<Ingredients> list = new List<Ingredients>();
            list.AddRange(array);
            this.Ingredients = list;
            this.Instructions = "bake 9000 degrees";
        }
        public Recipe(int Id, string Name, List<Ingredients> ingredients, string Instructions)
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
            if (ingredients.Count == 0)
            {
                throw new Exception("You can't have <1 ingredients, dude!");
            }
            else
            {
                this.Ingredients = ingredients;
            }

            this.Instructions = Instructions;
        }



        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Instructions { get; set; }
        [OneToMany(CascadeOperations=CascadeOperation.All)]
        public List<Ingredients> Ingredients { get; set; }
    }
}
