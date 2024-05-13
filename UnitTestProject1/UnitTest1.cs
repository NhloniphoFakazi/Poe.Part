using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace RecipeApp.Tests
{
    [TestFixture]
    public class RecipeTests
    {
        [Test]
        public void AddIngredient_AddsIngredientCorrectly()
        {
            // Arrange
            Recipe recipe = new Recipe("Test Recipe");

            // Act
            recipe.AddIngredient("Test Ingredient", 100, "grams", "Test Food Group");

            // Assert
            Assert.AreEqual(1, recipe.Ingredients.Count);
            Assert.AreEqual("Test Ingredient", recipe.Ingredients[0].ingredient);
            Assert.AreEqual(100, recipe.Ingredients[0].quantity);
            Assert.AreEqual("grams", recipe.Ingredients[0].unit);
            Assert.AreEqual("Test Food Group", recipe.Ingredients[0].foodGroup);
        }

        [Test]
        public void AddStep_AddsStepCorrectly()
        {
            // Arrange
            Recipe recipe = new Recipe("Test Recipe");

            // Act
            recipe.AddStep("Test Step");

            // Assert
            Assert.AreEqual(1, recipe.Steps.Count);
            Assert.AreEqual("Test Step", recipe.Steps[0]);
        }

        [Test]
        public void CalculateTotalCalories_CalculatesCorrectly()
        {
            // Arrange
            Recipe recipe = new Recipe("Test Recipe");
            recipe.AddIngredient("Ingredient 1", 100, "grams", "Food Group 1"); // Calories not required for this test
            recipe.AddIngredient("Ingredient 2", 200, "grams", "Food Group 2"); // Calories not required for this test

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(0, totalCalories); // Total calories should be 0 for this test
        }
    }

    [TestFixture]
    public class RecipeCollectionTests
    {
        [Test]
        public void AddRecipe_AddsRecipeCorrectly()
        {
            // Arrange
            RecipeCollection recipeCollection = new RecipeCollection();
            Recipe recipe = new Recipe("Test Recipe");

            // Act
            recipeCollection.AddRecipe(recipe);

            // Assert
            Assert.AreEqual(1, recipeCollection.Recipes.Count);
            Assert.AreEqual("Test Recipe", recipeCollection.Recipes[0].Name);
        }

        [Test]
        public void DisplayRecipes_DisplaysRecipesCorrectly()
        {
            // Arrange
            RecipeCollection recipeCollection = new RecipeCollection();
            Recipe recipe1 = new Recipe("Recipe 1");
            Recipe recipe2 = new Recipe("Recipe 2");
            recipeCollection.AddRecipe(recipe1);
            recipeCollection.AddRecipe(recipe2);

            // Redirect Console output for testing
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                recipeCollection.DisplayRecipes();
                string expectedOutput = "\nRECIPES:\r\nRecipe 1\r\nRecipe 2\r\n";

                // Assert
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }
    }
}
