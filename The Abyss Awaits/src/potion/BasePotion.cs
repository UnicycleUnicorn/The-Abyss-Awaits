using Microsoft.Xna.Framework;
using The_Abyss_Awaits.world;

namespace The_Abyss_Awaits.potion;

public class BasePotion {
    public Color Color;
    public int Length;
    public Dictionary<PotionIngredient, int> Recipe;

    private BasePotion(Color color, Dictionary<PotionIngredient, int> recipe) {
        var length = 0;
        foreach (var v in recipe) length += v.Value;
        Color = color;
        Recipe = recipe;
        Length = length;
    }

    public static BasePotion GenerateBasePotion(World world, Color basePotionColor, PotionConstraint potionConstraint) {
        return new BasePotion(basePotionColor, potionConstraint.GenerateRecipe(world.GenerationRandom));
    }

    public int GetIngredientQuantity(PotionIngredient ingredient) {
        return Recipe.GetValueOrDefault(ingredient, 0);
    }

    public double Similarity(PotionBuilder test) {
        double differences = 0;
        foreach (var ingredient in Enum.GetValues<PotionIngredient>()) {
            var d = GetIngredientQuantity(ingredient) - test.GetIngredientQuantity(ingredient);
            differences += Math.Abs(d);
        }

        return 1 - differences / (Length + test._length);
    }
}