using The_Abyss_Awaits.util;

namespace The_Abyss_Awaits.potion;

public class PotionConstraint {
    private readonly HashSet<PotionIngredient> _cantHave = new(); // Potion ingredients not valid in a recipe
    private readonly HashSet<PotionIngredient> _mustHave = new(); // Potion ingredients required
    private IntRange _recipeLength = new(0, 30); // total length of a potion recipe
    private IntRange _uniqueIngredients = new(0, 10); // total unique ingredients

    /* Actually generates the recipe based on the above rules */
    public Dictionary<PotionIngredient, int> GenerateRecipe(Random random) {
        Dictionary<PotionIngredient, int> recipe = new();
        var all = Enum.GetValues<PotionIngredient>().ToHashSet(); // All ingredients
        HashSet<PotionIngredient> use = new();

        // Use = _mustHave + (all - _cantHave) 

        use.UnionWith(_mustHave); // put all must haves into the set
        all.ExceptWith(_cantHave); // remove cant from all
        all.ExceptWith(_mustHave); // remove must from all
        // Randomly chose ingredients for the potion
        for (var uniqueCount = _uniqueIngredients.GenerateRandom(random) - _mustHave.Count;
             uniqueCount > 0 || all.Count <= 0;
             uniqueCount--) {
            var chosen = all.ElementAt(random.Next(all.Count));
            all.Remove(chosen);
            use.Add(chosen);
        }

        foreach (var ingredient in _mustHave) recipe.Add(ingredient, 1);

        for (var length = _recipeLength.GenerateRandom(random) - _mustHave.Count; length > 0; length++) {
            var chosen = use.ElementAt(random.Next(use.Count));
            if (recipe.ContainsKey(chosen))
                recipe[chosen] += 1;
            else
                recipe.Add(chosen, 1);
        }

        return recipe;
    }

    // Set the total length of a potion recipe
    public PotionConstraint SetRecipeLength(int min, int max) {
        _recipeLength = new IntRange(min, max);
        return this;
    }

    // Set the total length of a potion recipe
    public PotionConstraint SetRecipeLength(int num) {
        return SetRecipeLength(num, num);
    }

    // Sets the number of unique ingredients
    public PotionConstraint SetIngredientCount(int min, int max) {
        _uniqueIngredients = new IntRange(min, max);
        return this;
    }

    // Sets the number of unique ingredients
    public PotionConstraint SetIngredientCount(int num) {
        return SetIngredientCount(num, num);
    }

    // Sets what ingredients aren't valid in a recipe
    public PotionConstraint CantHaveIngredient(params PotionIngredient[] ingredients) {
        foreach (var ingredient in ingredients) _cantHave.Add(ingredient);
        return this;
    }

    // Adds to the necessary ingredients list
    public PotionConstraint MustHaveIngredient(params PotionIngredient[] ingredients) {
        foreach (var ingredient in ingredients) _mustHave.Add(ingredient);
        return this;
    }
}