using The_Abyss_Awaits.potion;

namespace The_Abyss_Awaits.world;

public class World {
    public readonly Dictionary<string, BasePotion> BasePotions;
    public readonly Random DungeonRandom; // Dungeon Generation
    public readonly Random GenerationRandom; // World Generation
    public readonly Random LootRandom; // Loot Events

    public readonly Random WorldRandom; // World Events

    // Variables relating to randomness
    public readonly int WorldSeed;

    private World(int seed) {
        // Generate randoms
        WorldSeed = seed;
        WorldRandom = new Random(seed);
        GenerationRandom = new Random(WorldRandom.Next());
        DungeonRandom = new Random(WorldRandom.Next());
        LootRandom = new Random(WorldRandom.Next());

        // Generate random base potions
        BasePotions = PotionGenerator.GeneratePotions(this);
    }

    public static World CreateNewWorld() {
        return new World(new Random().Next());
    }

    public static World CreateWorld(int seed) {
        return new World(seed);
    }
}