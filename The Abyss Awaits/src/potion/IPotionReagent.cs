using The_Abyss_Awaits.world;

namespace The_Abyss_Awaits.potion;

public interface IPotionReagent {
    public PotionIngredient[] GetPotionIngredients(World world);
}