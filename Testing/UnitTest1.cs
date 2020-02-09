using HW3N.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Testing
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestRecipeName()
        {
            var Expected = "Name is too short";
            string actual = null;
            Ingredients in1 = new Ingredients(1, "Eggs", 10, "Cups");
            Ingredients in2 = new Ingredients(2, "Flour", 3, "Almonds");
            Ingredients in3 = new Ingredients(3, "Baking Soda", 1000, "Teaspoons");
            Ingredients in4 = new Ingredients(4, "Milk", 30, "Liters");

            Ingredients[] array = new Ingredients[] { in1, in2, in3, in4 };
            List<Ingredients> list = new List<Ingredients>();
            list.AddRange(array);

            try
            {
                Recipe stuff = new Recipe(1, "cake", list, "kitty poop");
            }
            catch (Exception e)
            {
                actual = e.Message;

            }
            Assert.AreEqual(Expected, actual);
        }

        [Test]
        public void TestIngredientList()
        {
            var Expected = "You can't have <1 ingredients, dude!";
            string actual = null;
            Ingredients[] array = new Ingredients[] {};
            List<Ingredients> list = new List<Ingredients>();
            list.AddRange(array);

            try
            {
                Recipe stuff = new Recipe(1, "cakes1", list, "kitty poop");
            }
            catch (Exception e)
            {
                actual = e.Message;

            }
            Assert.AreEqual(Expected, actual);

        }
    }
}
   