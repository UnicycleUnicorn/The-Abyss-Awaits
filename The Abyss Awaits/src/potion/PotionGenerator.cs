using Microsoft.Xna.Framework;
using The_Abyss_Awaits.world;

namespace The_Abyss_Awaits.potion;

public static class PotionGenerator {
    public static List<Tuple<string, PotionConstraint, Color>> BasePotionsConstraints = GetBasePotionConstraints();

    public static Dictionary<string, BasePotion> GeneratePotions(World world) {
        return BasePotionsConstraints.ToDictionary(consts => consts.Item1,
            consts => BasePotion.GenerateBasePotion(world, consts.Item3, consts.Item2));
    }

    private static List<Tuple<string, PotionConstraint, Color>> GetBasePotionConstraints() {
        List<Tuple<string, PotionConstraint, Color>> constraints = new();

        PotionConstraint healthConstraint = new();
        healthConstraint.CantHaveIngredient();
        constraints.Add(new Tuple<string, PotionConstraint, Color>("Health", healthConstraint, Color.HotPink));

        return constraints;
    }
}