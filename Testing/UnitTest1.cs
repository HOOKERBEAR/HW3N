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
            int[] array = new int[] { 1, 2, 3, 4 };
            List<int> list = new List<int>();
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
            int[] array = new int[] {};
            List<int> list = new List<int>();
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
   