using System;
using System.Collections.Generic;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Recipe App!");

            RecipeCollection recipeCollection = new RecipeCollection();

            // Adding default recipes
            Recipe chickenRecipe = new Recipe("Chicken");
            chickenRecipe.AddIngredient("Chicken", 500, "grams", "Meat");
            chickenRecipe.AddIngredient("Salt", 1, "teaspoon", "Seasoning");
            chickenRecipe.AddIngredient("Pepper", 0.5, "teaspoon", "Seasoning");
            chickenRecipe.AddIngredient("Garlic", 2, "cloves", "Vegetable");
            chickenRecipe.AddIngredient("Olive Oil", 2, "tablespoon", "Condiment");
            chickenRecipe.AddStep("1. Marinate chicken with salt, pepper, and crushed garlic for 30 minutes.");
            chickenRecipe.AddStep("2. Heat olive oil in a pan.");
            chickenRecipe.AddStep("3. Fry chicken until golden brown on both sides.");
            chickenRecipe.AddStep("4. Serve hot.");

            recipeCollection.AddRecipe(chickenRecipe);

            Recipe chocolateCakeRecipe = new Recipe("Chocolate Cake");
            chocolateCakeRecipe.AddIngredient("Flour", 200, "grams", "Grain");
            chocolateCakeRecipe.AddIngredient("Sugar", 250, "grams", "Sweetener");
            chocolateCakeRecipe.AddIngredient("Cocoa Powder", 50, "grams", "Condiment");
            chocolateCakeRecipe.AddIngredient("Baking Powder", 1, "teaspoon", "Condiment");
            chocolateCakeRecipe.AddIngredient("Milk", 200, "milliliters", "Dairy");
            chocolateCakeRecipe.AddIngredient("Butter", 100, "grams", "Dairy");
            chocolateCakeRecipe.AddStep("1. Preheat oven to 180°C.");
            chocolateCakeRecipe.AddStep("2. Mix flour, sugar, cocoa powder, and baking powder.");
            chocolateCakeRecipe.AddStep("3. Add milk and melted butter. Mix well.");
            chocolateCakeRecipe.AddStep("4. Pour the batter into a greased cake pan.");
            chocolateCakeRecipe.AddStep("5. Bake for 30-35 minutes or until a toothpick inserted comes out clean.");
            chocolateCakeRecipe.AddStep("6. Let it cool before serving.");

            recipeCollection.AddRecipe(chocolateCakeRecipe);

            bool exitRequested = false;

            while (!exitRequested)
            {
                Console.WriteLine("\nMENU:");
                Console.WriteLine("1. Add a new recipe");
                Console.WriteLine("2. View recipes");
                Console.WriteLine("3. Scale a recipe");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        recipeCollection.AddRecipe();
                        break;
                    case "2":
                        recipeCollection.DisplayRecipes();
                        break;
                    case "3":
                        recipeCollection.ScaleRecipe();
                        break;
                    case "4":
                        exitRequested = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please enter a number between 1 and 4.");
                        break;
                }
            }
        }
    }

    class Recipe
    {
        public string Name { get; }
        private List<(string ingredient, double quantity, string unit, string foodGroup)> ingredients;
        private List<string> steps;

        public Recipe(string name)
        {
            Name = name;
            ingredients = new List<(string, double, string, string)>();
            steps = new List<string>();
        }

        public void AddIngredient(string name, double quantity, string unit, string foodGroup)
        {
            ingredients.Add((name, quantity, unit, foodGroup));
        }

        public void AddStep(string step)
        {
            steps.Add(step);
        }

        public double CalculateTotalCalories()
        {
            double totalCalories = 0;
            foreach (var (ingredient, quantity, _, _) in ingredients)
            {
                // Calculate calories based on some logic
                // For simplicity, let's assume 100 calories per unit
                totalCalories += quantity * 100;
            }
            return totalCalories;
        }

        public void DisplayRecipe()
        {
            Console.WriteLine($"\n{Name.ToUpper()} RECIPE:");
            Console.WriteLine("INGREDIENTS:");
            foreach (var (ingredient, quantity, unit, foodGroup) in ingredients)
            {
                Console.WriteLine($"{quantity} {unit} of {ingredient} (Food Group: {foodGroup})");
            }
            Console.WriteLine("\nSTEPS:");
            foreach (var step in steps)
            {
                Console.WriteLine(step);
            }
        }

        // Other methods for scaling, resetting quantities, etc.
    }

    class RecipeCollection
    {
        private List<Recipe> recipes;

        public RecipeCollection()
        {
            recipes = new List<Recipe>();
        }

        public void AddRecipe()
        {
            Console.Write("Enter recipe name: ");
            string name = Console.ReadLine();
            Recipe newRecipe = new Recipe(name);

            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.Write($"Enter ingredient {i + 1} name: ");
                string ingredientName = Console.ReadLine();

                Console.Write($"Enter quantity for {ingredientName}: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write($"Enter unit for {ingredientName}: ");
                string unit = Console.ReadLine();

                Console.Write($"Enter food group for {ingredientName}: ");
                string foodGroup = Console.ReadLine();

                newRecipe.AddIngredient(ingredientName, quantity, unit, foodGroup);
            }

            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.Write($"Enter step {i + 1} description: ");
                string stepDescription = Console.ReadLine();
                newRecipe.AddStep(stepDescription);
            }

            recipes.Add(newRecipe);
            Console.WriteLine("Recipe added successfully!");
        }

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public void DisplayRecipes()
        {
            Console.WriteLine("\nRECIPES:");
            foreach (var recipe in recipes)
            {
                Console.WriteLine(recipe.Name);
            }
            Console.Write("Enter the recipe name to view details: ");
            string recipeName = Console.ReadLine();
            var selectedRecipe = recipes.Find(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (selectedRecipe != null)
            {
                selectedRecipe.DisplayRecipe();
            }
            else
            {
                Console.WriteLine("Recipe not found!");
            }
        }

        public void ScaleRecipe()
        {
            Console.Write("Enter the recipe name to scale: ");
            string recipeName = Console.ReadLine();
            var selectedRecipe = recipes.Find(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (selectedRecipe != null)
            {
                selectedRecipe.DisplayRecipe();

                Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                double factor = double.Parse(Console.ReadLine());

                // Scaling logic
            }
            else
            {
                Console.WriteLine("Recipe not found!");
            }
        }

        // Other methods for deleting recipes, etc.
    }
}
