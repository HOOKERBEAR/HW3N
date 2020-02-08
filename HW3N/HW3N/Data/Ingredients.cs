using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace HW3N.Data
{
    public class Ingredients
    {

        public Ingredients()
        {
            this.Id = 0;
            this.Name = "flour";
            this.Amount = 4;
            this.Unit = "Cups";
        }
        public Ingredients(int Id, string Name, double Amount, string Units)
        {
            this.Id = Id;
            this.Name = Name;
            this.Unit = Unit;
            if (Amount < .01)
            {
                throw new Exception("You can't have <1 ingredients, dude!");
            }
            else
            {
                this.Amount = Amount;
            }


        }



        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public double Amount { get; set; }


    }
}
