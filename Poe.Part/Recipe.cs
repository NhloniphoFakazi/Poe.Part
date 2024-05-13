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
