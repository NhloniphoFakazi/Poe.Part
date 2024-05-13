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

