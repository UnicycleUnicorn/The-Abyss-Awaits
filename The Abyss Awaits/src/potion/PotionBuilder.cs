using Microsoft.Xna.Framework;
using The_Abyss_Awaits.world;

namespace The_Abyss_Awaits.potion;

public class PotionBuilder {
    private readonly Dictionary<PotionIngredient, int> _recipe = new();
    public int _length;

    public void AddIngredient(PotionIngredient ingredient, int quantity = 1) {
        if (_recipe.ContainsKey(ingredient))
            _recipe[ingredient] += quantity;
        else
            _recipe.Add(ingredient, quantity);
        _length += quantity;
    }

    public int GetIngredientQuantity(PotionIngredient ingredient) {
        return _recipe.GetValueOrDefault(ingredient, 0);
    }

    public Potion Build(World world) {
        var closest = "";
        var color = Color.Black;
        var similarity = double.MinValue;
        foreach (var basePotion in world.BasePotions) {
            var sim = basePotion.Value.Similarity(this);
            if (!(sim > similarity)) continue;
            color = basePotion.Value.Color;
            similarity = sim;
            closest = basePotion.Key;
        }

        color = Color.Multiply(color, (float)similarity);
        color.A = 255;
        return new Potion(closest, similarity, color);
    }
}